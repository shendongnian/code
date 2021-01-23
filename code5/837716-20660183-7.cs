    public abstract class MyMessageReceiverBase<T> : IMyMessageReceiver<T>
        where T : IMyMessage
    {
        public abstract void HandleMessage(T message);
        public void HandleMessage(IMyMessage message)
        {
            if (!(message is T))
                throw new InvalidOperationException();
            HandleMessage((T)message);
        }
        public abstract void Subscribe();
    }
