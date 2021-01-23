    public class PublishMessage
    {
        public PublishMessage(){
        }
    
        public void MyMethod()
        {
            //do something in this method, then send message:
            Messenger.Default.Send(new MyMessage() { /*initialize payload here */ });
        }
    }
