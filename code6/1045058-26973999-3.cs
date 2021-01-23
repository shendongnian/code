    public class MessageReceiver
    {
        private readonly IEnumerable<IMessageHandler> handlers;
        public MessageReceiver(IEnumerable<IMessageHandler> handlers)
        {
            this.handlers = handlers;
        }
        public void ReceiveMessage(IMessage message)
        {
            var handler = this.handlers.Where(h => h.MessageType == message.GetType()).FirstOrDefault();
            if (handler != null)
            {
                handler.Handle(message);
            }
            else
            {
                //Do something here, no handler found for message type
            }
        }
    }
