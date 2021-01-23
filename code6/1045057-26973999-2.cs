    public interface IMessageHandler
    {
        Type MessageType { get; }
        void Handle(IMessage message);
    }
    public class MessageHandlerAdapter<T> : IMessageHandler where T : IMessage
    {
        private readonly Func<IMessageHandler<T>> handlerFactory;
        public MessageHandlerAdapter(Func<IMessageHandler<T>> handlerFactory)
        {
            this.handlerFactory = handlerFactory;
        }
        public void Handle(IMessage message)
        {
            var handler = handlerFactory();
            handler.Handle((T)message);
        }
        public Type MessageType
        {
            get { return typeof(T); }
        }
    }
