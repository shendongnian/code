    public interface IDummy
    {
        string DoSomething();
    }
    public class Dummy: IDummy {
        public virtual string DoSomething()
        {
            return string.Empty;
        }
    }
    public class MyCustomException : Exception {}
    public class CustomIntercept: IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            throw new MyCustomException();
        }
    }
    internal class Program
    {
        private static void Main(string[] args)
        {
            var pg = new ProxyGenerator();
            GetValue(pg.CreateInterfaceProxyWithoutTarget<IDummy>(new CustomIntercept()));
            GetValue(pg.CreateClassProxy<Dummy>(new CustomIntercept()));
            GetValue(pg.CreateClassProxyWithTarget<Dummy>(new Dummy(), new CustomIntercept()));
            GetValue(pg.CreateInterfaceProxyWithTarget<IDummy>(new Dummy(), new CustomIntercept()));
        }
        private static void GetValue(IDummy dummy)
        {
            try
            {
                dummy.DoSomething();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType().Name);
            }
        }
    }
