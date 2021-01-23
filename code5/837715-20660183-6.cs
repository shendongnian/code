    public interface IMyMessageReceiver
    {
        void HandleMessage(IMyMessage message);
        void Subscribe();
    }
    public interface IMyMessageReceiver<in T> : IMyMessageReceiver
        where T : IMyMessage
    {
        void HandleMessage(T message);
    }
