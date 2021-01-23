    using System;
    using System.Reflection;
    using Ninject;
    using Ninject.Modules;
    public interface ILogger
    {
        void Log(string msg);
    }
    public class BaseLogger : ILogger
    {
        public void Log(string msg)
        {
            Console.WriteLine(msg);
        }
    }
    public class CustomerSpecificLogger : ILogger
    {
        private ILogger BaseLogger { get; set; }
        public CustomerSpecificLogger(ILogger baseLogger)
        {
            BaseLogger = baseLogger;
        }
        public void Log(string msg)
        {
            //Log to somewhere specific per customer request
            BaseLogger.Log(msg);
        }
    }
    // kernel.Load() in Program.Main() automatically load and bind this.
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
    #if true // or some App.config, anything...
            Bind<ILogger>().To<BaseLogger>().InSingletonScope();
    #else
            Bind<ILogger>().To<CustomerSpecificLogger>().InSingletonScope().WithConstructorArgument("baseLogger", new BaseLogger());
    #endif
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            var logger = kernel.Get<ILogger>();
            logger.Log("Hello!");
        }
    }
