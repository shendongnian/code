    public class MessageHandlerA : MessageHandler {
        public override void HandleTypedMessage(BaseMessage msg) {
    		this.HandleTypedMessageCore((dynamic) msg);
    	}
        private void HandleTypedMessageCore(BaseMessage msg) {
            Console.WriteLine("Did nothing with " + msg.MessageType);
        }
    
        private void HandleTypedMessageCore(MessageA msg) {
            Console.WriteLine("Handled message a");
        }
    }
