    public class Logger
    {
        private ILog _Log { get; set; }
        public Logger(Type declaringType)
        {
            _Log = LogManager.GetLogger(declaringType);
        }
        public void Error(Exception exception, [CallerMemberName] string callerMemberName = "")
        {
            _Log.Error(callerMemberName, exception);
        }
    }
