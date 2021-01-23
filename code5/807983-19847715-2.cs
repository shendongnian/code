    namespace LoggingTest
    {
        public class LoggerWrapper : ILoggerWrapper
        {
            private readonly ILog _log;
            public LoggerWrapper(ILog log)
            {
                _log = log;
            }     
        
            public Action<object> Debug { get { return _log.Debug; } }
            public Action<object, Exception> DebugEx { get { return _log.Debug; } }
            public LogFormat DebugFormat { get { return _log.DebugFormat; } }
            public Action<object> Info { get { return _log.Info; } }
            public Action<object, Exception> InfoEx { get { return _log.Info; } }
            public LogFormat InfoFormat { get { return _log.InfoFormat; } }
            public Action<object> Warn { get { return _log.Warn; } }
            public Action<object, Exception> WarnEx { get { return _log.Warn; } }
            public LogFormat WarnFormat { get { return _log.WarnFormat; } }
            public Action<object> Error { get { return _log.Error; } }
            public Action<object, Exception> ErrorEx { get { return _log.Error; } }
            public LogFormat ErrorFormat { get { return _log.ErrorFormat; } }
            public Action<object> Fatal { get { return _log.Fatal; } }
            public Action<object, Exception> FatalEx { get { return _log.Fatal; } }
            public LogFormat FatalFormat { get { return _log.FatalFormat; } }
        }
    }
