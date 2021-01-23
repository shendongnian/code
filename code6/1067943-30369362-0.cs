    public class GlobalErrorHandler : IWantToRunWhenBusStartsAndStops
    {
        private readonly ILogger _logger;
        private readonly BusNotifications _busNotifications;
        readonly List<IDisposable> _notificationSubscriptions = new List<IDisposable>();
        public GlobalErrorHandler(ILogger logger, BusNotifications busNotifications)
        {
            _logger = logger;
            _busNotifications = busNotifications;
        }
        public void Start()
        {
            _notificationSubscriptions.Add(_busNotifications.Errors.MessageHasFailedAFirstLevelRetryAttempt.Subscribe(LogWhenMessageSentToFirstLevelRetry));
        }
        public void Stop()
        {
            foreach (var subscription in _notificationSubscriptions)
            {
                subscription.Dispose();
            }
        }
        private void LogWhenMessageSentToFirstLevelRetry(FirstLevelRetry message)
        {
            var properties = new
            {
                MessageType = message.Headers["NServiceBus.EnclosedMessageTypes"],
                MessageId = message.Headers["NServiceBus.MessageId"],
                OriginatingMachine = message.Headers["NServiceBus.OriginatingMachine"],
                OriginatingEndpoint = message.Headers["NServiceBus.OriginatingEndpoint"],
                ExceptionType = message.Headers["NServiceBus.ExceptionInfo.ExceptionType"],
                ExceptionMessage = message.Headers["NServiceBus.ExceptionInfo.Message"],
                ExceptionSource = message.Headers["NServiceBus.ExceptionInfo.Source"],
                TimeSent = message.Headers["NServiceBus.TimeSent"]
            };
            _logger.Error("Message sent to first level retry. " + properties, message.Exception);
        }
    }
