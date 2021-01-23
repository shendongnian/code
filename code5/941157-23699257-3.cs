    public static class MessageProcessor
    {
        private static class MessageHandlerHolder<TMessage>
        {
            public static IMessageHandler<TMessage> Handler;
        }
        public static void AddHandler<TMessage>(IMessageHandler<TMessage> handler)
        {
            MessageHandlerHolder<TMessage>.Handler = handler;
        }
        public static void Handle<TMessage>(TMessage message)
        {
            MessageHandlerHolder<TMessage>.Handler.Handle(message);
        }
    }
