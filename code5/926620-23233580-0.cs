    public static class LogExtensions
    {
        public static void WriteWithCallerInfo(
            this Log log,
            string s,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            Monitor.Enter(log);
            try
            {
                string logEntry = string.Format(s, memberName, sourceFilePath, sourceLineNumber);
                log.Write(logEntry);
            }
            finally
            {
                Monitor.Exit(log);
            }
        }
    }
