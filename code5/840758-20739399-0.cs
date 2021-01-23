    public static class LoggerHelper
    {
        public void WriteError(string message,Exception ex, Type type)
        {
            public static readonly log4net.ILog log = log4net.LogManager.GetLogger(type);
            log.Error(message, ex);
        }
    }
