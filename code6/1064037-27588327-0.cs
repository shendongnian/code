    // Create a resolver(abstract factory) for the IRepository interface type
    var resolver = myContainer.Resolve<Func<IRepository>>();
    // ... other code here...
    // Register mappings for the IRepository interface to appropriate concrete types
    myContainer.RegisterType<IRepository, ARepository>("A");
    myContainer.RegisterType<IRepository, BRepository>("B");
