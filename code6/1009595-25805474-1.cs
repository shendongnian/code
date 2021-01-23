    public class MyFactory : NLogFactory
    {
        public override ILogger Create(string name)
        {
            var il = base.Create(name);
            var pg =  new ProxyGenerator();
            return pg.CreateInterfaceProxyWithTarget<ILogger>(il, new LoggingInterceptor());
        }
    }
    public class LoggingInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            //Some modification to message here
            invocation.Proceed();
        }
    }
    internal class Program
    {
        private static void Main(string[] args)
        {
            var container = new WindsorContainer();
            container.AddFacility<LoggingFacility>(f => f.UseNLog().LogUsing<MyFactory>());
            var logger = container.Resolve<ILogger>();
            logger.Debug("data"); // we intercept this call, success
            Console.ReadLine();
        }
    }
