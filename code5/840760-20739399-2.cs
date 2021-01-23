    public static class LoggerHelper
    {
        public static void WriteError(string message,Exception ex, Type type)
        {
            var log = log4net.LogManager.GetLogger(type);
            log.Error(message, ex);
        }
    }
