    public interface ISubscription
    {
        void Unsubscribe();
    }
    public interface INotification<TMessageType> : ISubscription where TMessageType : class, IMessage
    {
        void Register(Action<TMessageType, ISubscription> callback);
    }
    public interface INotificationProcessor
    {
        void ProcessMessage(IMessage message);
    }
