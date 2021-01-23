    var container = new UnityContainer();
    container.AddNewExtension<Interception>()
             .RegisterType<TesCallHandler>()
             .RegisterType<IFoo, Foo>(new Interceptor<TransparentProxyInterceptor>(),
                 new InterceptionBehavior<PolicyInjectionBehavior>())
             .Configure<Interception>()
             .AddPolicy("TestPolicy")
             .AddCallHandler(new TestCallHandler());
    var foo = container.Resolve<IFoo>();
    foo.Test();
