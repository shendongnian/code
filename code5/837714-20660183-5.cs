    public static class MyMessagePublisher
    {
        static readonly Dictionary<Type, IMyMessageListeners<IMyMessage>> _subscribers;
        static MyMessagePublisher()
        {
            _subscribers = new Dictionary<Type, IMyMessageListeners<IMyMessage>>();
        }
        public static void Subscribe<T>(IMyMessageReceiver<T> receiver) where T : IMyMessage
        {
            Type messageType = typeof(T);
            IMyMessageListeners<IMyMessage> listeners;
            if (!_subscribers.TryGetValue(messageType, out listeners))
            {
                // no list found, so create it
                listeners = new MyMessageListeners<IMyMessage>();
                // This works now because IMessageListeners is covariant
                _subscribers.Add(messageType, newListeners);
            }
            // I would then find the right list and add the receiver it to it but haven't got this far
            listeners.Add(receiver); // most likely, not sure what you're doing at this point
        }
    }
