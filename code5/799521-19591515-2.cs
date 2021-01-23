    public static class Logger
    {
        private static ILog _log;
        static Logger()
        {
            log4net.Config.XmlConfigurator.Configure();
            _log = log4net.LogManager.GetLogger("Log4Net");
        }
        public static void Debug(string message)
        {
            if (_log.IsDebugEnabled)
                _log.Debug(message);
        }
        public static void Info(string message)
        {
            _log.Info(message);
        }
        public static void Warn(string message)
        {
            _log.Warn(message);
        }
        public static void Error(string message)
        {
            _log.Error(message);
        }
        public static void Error(string message, Exception ex)
        {
            _log.Error(message, ex);
        }
        public static void Fatal(string message)
        {
            _log.Fatal(message);
        }
        public static void Fatal(string message, Exception ex)
        {
            _log.Fatal(message, ex);
        }
    }
