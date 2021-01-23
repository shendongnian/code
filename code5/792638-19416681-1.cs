    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer container = new UnityContainer();
            container.AddNewExtension<Interception>();
            container.RegisterType<ValidationHandler>(new ContainerControlledLifetimeManager());
            container.RegisterType<TransactionHandler>(new ContainerControlledLifetimeManager());
            container.RegisterType<NotifyHandler>(new ContainerControlledLifetimeManager());
            container.RegisterType<TestClass>(
                new InterceptionBehavior<PolicyInjectionBehavior>(),
                new Interceptor<VirtualMethodInterceptor>()); 
            var testClass = container.Resolve<TestClass>();
            testClass.TestProperty = 5;
        }
    }
