    public class WcfAppender : BufferingAppenderSkeleton
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(WcfAppender));
        private static readonly string LoggerName = typeof(WcfAppender).FullName;
        public override void ActivateOptions()
        {
            base.ActivateOptions();
            this.Fix = FixFlags.All;
        }
        protected override bool FilterEvent(LoggingEvent loggingEvent)
        {
            if (loggingEvent.LoggerName.Equals(LoggerName))
                return false;
            else
                return base.FilterEvent(loggingEvent);
        }
        protected override void SendBuffer(LoggingEvent[] events)
        {
            try
            {
                var clientFactory = log4net.LogManager.GetRepository().Properties["ClientLoggerFactory"] as Func<ClientLoggerClient>;
                if (clientFactory != null)
                {
                    var client = clientFactory();
                    try
                    {
                        client.LogRecord(events.Select(CreateWrapper).ToArray());
                    }
                    finally
                    {
                        client.CloseConnection();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Error sending error log to server", ex);
            }
        }
        private ErrorMessageWrapper CreateWrapper(LoggingEvent arg)
        {
            var wrapper = new ErrorMessageWrapper();
            //SNIP...
            return wrapper;
        }
    }
