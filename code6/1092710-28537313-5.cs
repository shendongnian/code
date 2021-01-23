    // NOTE: This interface is not generic
    public interface IMessageHandler
    {
        void Execute(object message);
    }
    
    public abstract class MessageHandler<T> : IMessageHandler
    {
        public abstract void Execute(T message);
    
        // NOTE: Here we explicitly implement the IMessageHandler
        void IMessageHandler.Execute(object message)
        {
            Execute((T)message);
        }
    }
