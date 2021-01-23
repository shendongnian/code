    public interface IMyMessage
    {
    }
    public interface IMyMessageReceiver<T> where T : IMyMessage
    {
        void HandleMessage(T message);
        void Subscribe();
    }
    public static class MyMessagePublisher
    {
        private static readonly KeyedByTypeCollection<IList> Subscribers;
        static MyMessagePublisher()
        {
            Subscribers = new KeyedByTypeCollection<IList>();
        }
        public static void Subscribe<T>(IMyMessageReceiver<T> receiver) where T : IMyMessage
        {
            List<IMyMessageReceiver<T>> listeners = Subscribers.Find<List<IMyMessageReceiver<T>>>();
            if (listeners == null)
            {
                listeners = new List<IMyMessageReceiver<T>>();
                Subscribers.Add(listeners);
            }
            // Now you can use the listeners list
            listeners.Add(receiver);
        }
    }
