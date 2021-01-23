    public class Message
    {
        public Message(MessageType messageType, object message)
        {
            MessageType = messageType;
            MessageObject = message;
        }
        public MessageType MessageType { get; private set; }
        public object MessageObject { get; private set; }
    }
