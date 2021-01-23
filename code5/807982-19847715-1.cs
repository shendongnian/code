    namespace LoggingTest
    {
        public delegate void LogFormat(string format, params object[] args);
        public interface ILoggerWrapper
        {
            Action<object> Debug { get; } 
        
            Action<object, Exception> DebugEx { get; }
            LogFormat DebugFormat { get; }
            Action<object> Info { get; }
            Action<object, Exception> InfoEx { get; }
            LogFormat InfoFormat { get; }
            Action<object> Warn { get; }
            Action<object, Exception> WarnEx { get; }
            LogFormat WarnFormat { get; }
            Action<object> Error { get; }
            Action<object, Exception> ErrorEx { get; }
            LogFormat ErrorFormat { get; }
        
            Action<object> Fatal { get; }
            Action<object, Exception> FatalEx { get; }
            LogFormat FatalFormat { get; }
        }
    }
