        private static IWindsorContainer _container;
        static Program()
        {
            Debug.Listeners.Add(new ConsoleTraceListener());
            _container = new WindsorContainer().Install(FromAssembly.This());
            _container.Register(Component.For<ICommonLogger>().ImplementedBy(typeof(CommonLogger)).LifeStyle.Singleton);
        }
        private static ICommonLogger Logger { get; set; }
        private static void Main(string[] args)
        {
            Logger = _container.Resolve<ICommonLogger>();
            Logger.Write("Text");
            Console.ReadLine();
        }
        public interface ICommonLogger
        {
            void Write(string str);
        }
        public class CommonLogger : ICommonLogger
        {
            public void Write(string str)
            {
                Console.WriteLine(str);
            }
        }
