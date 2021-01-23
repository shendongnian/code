    public class TraceSourceLogger : ILogger
    {
        private TraceSource _traceSource;
        public TraceSourceLogger(object that)
        {
            _traceSource = new TraceSource(that.GetType().Namespace);
        }
        public void TraceInformation(string message)
        {
            _traceSource.TraceInformation(message);
        }
        public void TraceWarning(string message)
        {
            _traceSource.TraceEvent(TraceEventType.Warning, 1, message);
        }
        public void TraceError(Exception ex)
        {
            _traceSource.TraceEvent(TraceEventType.Error, 2, ex.Message);
            _traceSource.TraceData(TraceEventType.Error, 2, ex);
        }
        public void TraceInformation(Func<string> messageProvider)
        {
            if (_traceSource.Switch.ShouldTrace(TraceEventType.Information))
            {
                TraceInformation(messageProvider());
            }
        }
        public void TraceWarning(Func<string> messageProvider)
        {
            if (_traceSource.Switch.ShouldTrace(TraceEventType.Warning))
            {
                TraceWarning(messageProvider());
            }
        }
    }
