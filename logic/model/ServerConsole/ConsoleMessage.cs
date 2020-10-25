﻿using System;

namespace Fork.Logic.Model.ServerConsole
{
    public class ConsoleMessage
    {
        public enum MessageLevel
        {
            INFO, WARN, ERROR, SUCCESS
        }
        
        public string Content { get; }
        public MessageLevel Level { get; }
        public DateTime CreationTime { get; }

        public ConsoleMessage(string content)
        {
            Content = content;
            Level = CategorizeContent(content);
            CreationTime = DateTime.Now;
        }

        public ConsoleMessage(string content, MessageLevel level)
        {
            Content = content;
            Level = level;
            CreationTime = DateTime.Now;
        }

        private MessageLevel CategorizeContent(string content)
        {
            if (content.Contains("ERROR") || content.Contains("Exception") || content.Trim().StartsWith("at "))
            {
                return MessageLevel.ERROR;
            }
            if (content.Contains("WARN"))
            {
                return MessageLevel.WARN;
            }
            return MessageLevel.INFO;
        }

        public override string ToString()
        {
            return Content;
        }
    }
}