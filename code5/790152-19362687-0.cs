    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel();
            kernel.Bind<IFoo>().ToMethod(ctx => ctx.Kernel.Get<Foo>());
            kernel.Bind<Foo>().ToSelf().Intercept().With<SomeInterceptor>();
            var foo = kernel.Get<IFoo>();
            foo.DoSomething();
            Console.WriteLine(foo.GetType());
            Console.Read();
        }
    }
    public interface IFoo
    {
        void DoSomething();
    }
    public class Foo : IFoo
    {
        public virtual void DoSomething()
        {
            Console.WriteLine("doing something");
        }
    }
    public class SomeInterceptor : IInterceptor
    {
        public SomeInterceptor()
        {
            Console.WriteLine("interceptor created");
        }
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("before");
            invocation.Proceed();
            Console.WriteLine("after");
        }
    }
