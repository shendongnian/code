    public class NotificationManager
    {
        private ConcurrentDictionary<Type, List<INotificationProcessor>> listeners =
            new ConcurrentDictionary<Type, List<INotificationProcessor>>();
        public ISubscription Subscribe<TMessageType>(Action<TMessageType, ISubscription> callback) where TMessageType : class, IMessage
        {
            Type messageType = typeof(TMessageType);
            // Create our key if it doesn't exist along with an empty collection as the value.
            if (!listeners.ContainsKey(messageType))
            {
                listeners.TryAdd(messageType, new List<INotificationProcessor>());
            }
            // Add our notification to our listener collection so we can publish to it later, then return it.
            var handler = new Notification<TMessageType>();
            handler.Register(callback);
            List<INotificationProcessor> subscribers = listeners[messageType];
            lock (subscribers)
            {
                subscribers.Add(handler);
            }
            return handler;
        }
        public void Publish<T>(T message) where T : class, IMessage
        {
            Type messageType = message.GetType();
            if (!listeners.ContainsKey(messageType))
            {
                return;
            }
            // Exception is thrown here due to variance issues.
            foreach (INotificationProcessor handler in listeners[messageType])
            {
                handler.ProcessMessage(message);
            }
        }
    }
