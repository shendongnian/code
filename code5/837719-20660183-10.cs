    public static class MyMessagePublisher
    {
        static readonly Dictionary<Type, IMyMessageListeners> _subscribers = new Dictionary<Type, IMyMessageListeners>();
        // I added this too, since I think this is how you intend to use it
        public static void Publish<T>(T message) where T : IMyMessage
        {
            Type messageType = typeof(T);
            IMyMessageListeners listeners;
            if (_subscribers.TryGetValue(messageType, out listeners))
                listeners.Send(message);
        }
        public static void Subscribe<T>(IMyMessageReceiver<T> receiver) where T : IMyMessage
        {
            Type messageType = typeof(T);
            IMyMessageListeners listeners;
            if (!_subscribers.TryGetValue(messageType, out listeners))
            {
                // no list found, so create it
                listeners = new MyMessageListeners();
                _subscribers.Add(messageType, listeners);
            }
            listeners.Add(receiver);
        }
    }
