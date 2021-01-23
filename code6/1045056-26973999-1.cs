    public class MessageAHandler : IMessageHandler<MessageA>
    {
        public void Handle(MessageA message)
        {
            message.MarkAsHandled();
        }
    }
    public class MessageBHandler : IMessageHandler<MessageB>
    {
        public void Handle(MessageB message)
        {
            message.MarkAsHandled();
        }
    }
