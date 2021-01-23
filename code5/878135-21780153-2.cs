    public interface IMessage { }
    public class MessageA : IMessage { }
    public class MessageB : IMessage { }
    public interface IMessageHandler<T>
        where T : IMessage
    {
        void Handle(T message);
    }
    public class MessageHandlerA : IMessageHandler<MessageA>
    {
        public void Handle(MessageA message)
        {
            Console.WriteLine("Message A handled");
        }
    }
    public class MessageHandlerB : IMessageHandler<MessageB>
    {
        public void Handle(MessageB message)
        {
            Console.WriteLine("Message B handled");
        }
    }
    public class MessageProcessor
    {
        private static readonly MethodInfo GenericProcessMethod = typeof(MessageProcessor).GetMethod("ProcessGeneric");
        private readonly IResolutionRoot resolutionRoot;
        public MessageProcessor(IResolutionRoot resolutionRoot)
        {
            this.resolutionRoot = resolutionRoot;
        }
        public void Process(IMessage message)
        {
            GenericProcessMethod.MakeGenericMethod(message.GetType())
                .Invoke(this, new object[] { message });
        }
        public void ProcessGeneric<TMessage>(TMessage message)
            where TMessage : IMessage
        {
            var handler = this.resolutionRoot.Get<IMessageHandler<TMessage>>();
            handler.Handle(message);
        }
    }
    public class Test
    {
        private readonly IKernel kernel;
        public Test()
        {
            this.kernel = new StandardKernel();
            this.kernel.Bind(x => x
                .FromThisAssembly()
                .IncludingNonePublicTypes()
                .SelectAllClasses()
                .InheritedFrom(typeof(IMessageHandler<>))
                .BindSingleInterface());
        }
        [Fact]
        public void IntegrationTest()
        {
            var messageProcessor = this.kernel.Get<MessageProcessor>();
            messageProcessor.Process(new MessageA());
            messageProcessor.Process(new MessageB());
        }
    }
