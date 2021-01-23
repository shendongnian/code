    public interface IMyMessageReceiver
    {
        void HandleMessage(IMyMessage message);
        void Subscribe();
    }
    
    public class MyMessageReceiver<T> : IMyMessageReceiver where T: IMyMessage
    {
        void IMyMessageReceiver.HandleMessage(IMyMessage message)
        {
            HandleMessage(message as T);
        }
    
        public void HandleMessage(T message) {...}
        public void Subscribe() {...}
    }
