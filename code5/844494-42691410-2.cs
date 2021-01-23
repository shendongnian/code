    public class NLogLogger : ILog
    {
        private readonly Logger _log;
        public NLogLogger()
        {
            _log = LogManager.GetCurrentClassLogger();
        }
        public NLogLogger(Type type)
        {
            _log = LogManager.GetLogger(type.FullName);
        }
    }
