    class Logger
    {
        private readonly string logFileName;
        public Logger(string logFileName)
        {
            this.logFileName = logFileName;
        }
        internal void WriteLog(string message)
        {
            File.AppendAllText(logFileName, message);
        }
    }
