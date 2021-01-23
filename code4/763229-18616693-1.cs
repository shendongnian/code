    [ConfigurationElementType(typeof(CustomTraceListenerData))]
    public class ExceptionThrowingTraceListener : CustomTraceListener
    {
        private void Throw()
        {
            throw new Exception("An Error occurred logging.  Check error logs.");
        }
        
        public override void TraceData(TraceEventCache eventCache, string source, TraceEventType eventType, int id, object data)
        {
            Throw();
        }
        public override void Write(string message)
        {
            Throw();
        }
        public override void WriteLine(string message)
        {
            Throw();
        }
    }
