    // register interceptors
    _container.Register(
    	Classes.FromAssemblyInThisApplication()
    	.BasedOn<IInterceptor>()
    	.WithServiceBase()
    	.Configure(c => c.Named(c.Implementation.Name))
    );
    
    // apply them
    _container.Register
    (
    	Component.For<IService>()
    		.ImplementedBy<ServicesImplementation.Service>()
    		.Named("Service")
    		.LifestylePerWcfOperation()
    		.Interceptors("LoggingInterceptor")
    );
