    public class CustomLogger : ICustomLogger 
    {
        public bool WriteCore(TraceEventType eventType, int eventId, object state, 
            Exception exception, Func<object, Exception, string> formatter)
        {
            ILog logger = LogManager.GetLogger("myowinlogger");
            switch (eventType){
                case(TraceEventType.Critical): 
                {
                    logger.Fatal(...);
                }
                ....
        }
    }
