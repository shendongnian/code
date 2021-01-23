    public class MessageReceiver
    {
        public MessageReceiver()
        {
            Messenger.Default.Register<MyMessage>(this, message => Foo(message));
        }
    
        public void Foo(MyMessage message)
        {
            //do stuff
        }
    }
