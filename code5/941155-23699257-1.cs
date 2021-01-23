    public class MessageProcessor
    {
        private readonly IDictionary<Type, Action<object>> _messageHandlers = new Dictionary<Type, Action<object>>();
        public void AddHandler<TMessage>(IMessageHandler<TMessage> handler)
        {
            AddHandler((Action<TMessage>) handler.Handle);
        }
        public void AddHandler<TMessage>(Action<TMessage> handler)
        {
            var messageType = typeof (TMessage);
            _messageHandlers.Add(messageType, msg => handler((TMessage) msg));//Note: downcast
        }
        public void Handle<TMessage>(TMessage message)
        {
            var messageType = typeof (TMessage);
            _messageHandlers[messageType](message);
            //OR (if runtime type should be used):
            _messageHandlers[message.GetType()](message);
        }
    }
