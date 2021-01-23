    public interface ILowerCaseWriter
    {
        void Write(string message);
    }
    public class LowerCaseWriter : ILowerCaseWriter
    {
        public void Write(string message)
        {
            Console.WriteLine(message.ToLower());
        }
    }
    public interface IUpperCaseWriter
    {
        void Write(string message, int number);
    }
    public class UpperCaseWriter : IUpperCaseWriter
    {
        public void Write(string message, int number)
        {
            Console.WriteLine("{0}:{1}", number, message.ToUpper());
        }
    }
    public interface ISubscriber
    {
        void Write();
    }
    public class Subscriber1 : ISubscriber
    {
        private ILowerCaseWriter _writer;
        public Subscriber1(ILowerCaseWriter writer)
        {
            _writer = writer;
        }
        public void Write()
        {
            _writer.Write("Using subscriber 1");
        }
    }
    public class Subscriber2 : ISubscriber
    {
        private IUpperCaseWriter _writer;
        public Subscriber2(IUpperCaseWriter writer)
        {
            _writer = writer;
        }
        public void Write()
        {
            _writer.Write("Using subscriber 2", 2);
        }
    }
    public class SubscriberFactory
    {
        private UnityContainer _container;
        public SubscriberFactory()
        {
            _container = new UnityContainer();
            _container.RegisterType<ILowerCaseWriter, LowerCaseWriter>();
            _container.RegisterType<IUpperCaseWriter, UpperCaseWriter>();
            _container.RegisterType<ISubscriber, Subscriber1>("Subscriber1");
            _container.RegisterType<ISubscriber, Subscriber2>("Subscriber2");
        }
        public ISubscriber GetSubscriber(int type)
        {
            switch (type)
            {
                case 1:
                    return _container.Resolve<ISubscriber>("Subscriber1");
                case 2:
                    return _container.Resolve<ISubscriber>("Subscriber2");
                default:
                    throw new Exception();
            }
        }
    }
    class Program
    {
        private static void Main(string[] args)
        {
            var factory = new SubscriberFactory();
            var subscriber = factory.GetSubscriber(1);
            subscriber.Write();
            Console.ReadLine();
        }
    }
