    public static class MyMessagePublisher
    {
        private static readonly KeyedByTypeCollection<object> Subscribers;
        static MyMessagePublisher()
        {
            Subscribers = new KeyedByTypeCollection<object>();
        }
        public static void Subscribe<T>(IMyMessageReceiver<T> receiver) where T : IMyMessage
        {
            IList<IMyMessageReceiver<T>> listeners = Subscribers.Find<IList<IMyMessageReceiver<T>>>();
            if (listeners == null)
            {
                listeners = new List<IMyMessageReceiver<T>>();
                Subscribers.Add(listeners);
            }
            // Now you can use currentList
            listeners.Add(receiver);
        }
    }
