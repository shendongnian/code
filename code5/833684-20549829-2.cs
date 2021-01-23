    class Program
    {
        private static IKernel _kernel;
        static void Main(string[] args)
        {
            _kernel = new StandardKernel();
            _kernel.Bind<ISomeClass>().To<SomeClass>().InTransientScope();
            
            while (true)
            {
                LifetimeController = new object();
                SomeFunc();
                Thread.Sleep(10);
            }
        }
        public static void SomeFunc()
        {
            _kernel.Get<ISomeClass>();
        }
        public interface ISomeClass { }
        public class SomeClass : ISomeClass
        {
            public SomeDisposableClass C = new SomeDisposableClass();
            ~SomeClass()
            {
                Console.WriteLine("{0} finalized", this);
                C.Dispose();
            }
        }
        public class SomeDisposableClass : IDisposable
        {
            private byte[] bytes = new byte[1000000];
            public void Dispose()
            {
                Console.WriteLine("{0} disposed", this);
            }
        }
    }
