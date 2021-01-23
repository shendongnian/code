    public class MessageProcessor
    {
        private static class MessageHandlerHolder<TMessage>
        {
            public static readonly ConditionalWeakTable<MessageProcessor, IMessageHandler<TMessage>> MessageHandlers =
                new ConditionalWeakTable<MessageProcessor, IMessageHandler<TMessage>>();
        }
        public void AddHandler<TMessage>(IMessageHandler<TMessage> handler)
        {
            MessageHandlerHolder<TMessage>.MessageHandlers.Add(this, handler);
        }
        public void Handle<TMessage>(TMessage message)
        {
            IMessageHandler<TMessage> handler;
            if (!MessageHandlerHolder<TMessage>.MessageHandlers.TryGetValue(this, out handler))
                throw new InvalidOperationException("...");
            handler.Handle(message);
        }
    }
