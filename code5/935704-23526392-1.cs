    class LogMessage
    {
        public string Filepath { get; set; }
        public string Text { get; set; }
    }
    BlockingCollection<LogMessage> _logMessages = new BlockingCollection<LogMessage>();
