    class Program
    {
        public static void Main(String [] args)
        {
            var container = new WindsorContainer();
            container.Register(Component.For<TestInterceptor>().Named("test"));
            container.Register(Component.For<InnerInterface>().ImplementedBy<InnerClass>().Interceptors(InterceptorReference.ForKey("test")).Anywhere);
            // this row below will throw the exception
            var innerClassInstance = container.Resolve<InnerInterface>();
        }
        
        class InnerClass : InnerInterface  { }
        
        interface InnerInterface { }
        
        class TestInterceptor : IInterceptor
        {
            public void Intercept(IInvocation invocation)
            {
                throw new NotImplementedException();
            }
        }
    }
