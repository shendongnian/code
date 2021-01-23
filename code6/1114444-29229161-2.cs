    public class Logger
    {
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(typeof(Logger));
        static Logger()
        {
            log4net.Config.XmlConfigurator.Configure();
        }
        public void Error(string format, params object[] args)
        {
            _log.Error(string.Format(format, args));
        }
        //...
    }
