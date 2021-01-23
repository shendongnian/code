    public class RandomMessage
    {
        public static void Main()
        {
            // Register services with InstanceFactory at the start of Main method
            InstanceFactory.Register(typeof(IMessageProvider), () => new MessageProvider());
    
            IMessageProvider provider = InstanceFactory.InstanceOf(typeof(IMessageProvider)) as IMessageProvider;
            Console.WriteLine(String.Format("The message is:\n{0}", provider.Message));
        }
    }
