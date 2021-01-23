    public class HandlerA : MessageHandler<MessageA>
    {
        public override void Execute(MessageA message)
        {
            Console.WriteLine("Message A");
        }
    }
    
    public class HandlerB : MessageHandler<MessageB>
    {
        public override void Execute(MessageB message)
        {
            Console.WriteLine("Message B");
        }
    }
