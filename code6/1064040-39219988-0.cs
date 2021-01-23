    // register interfaces to implementations with a named dependency 
    myContainer.RegisterType<IRepository, ARepository>("A");
    myContainer.RegisterType<IRepository, BRepository>("B");
    // register Injection factory to resolve the dependency
    container.RegisterType<Func<string, IRepository>>(
                new InjectionFactory(c =>
                new Func<string, IRepository>(name => c.Resolve<IRepository>(name)))
    );
