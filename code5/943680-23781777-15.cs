    // This instance lives as long as its scope and will be disposed by the container.
    container.RegisterLifetimeScope<IUnitOfWork, DisposableUnitOfWork>();
    
    // Register the command handler
    container.Register<ICommandHandler<AddCustomer>, AddCustomerCommandHandler>();
    // register the proxy that adds the scoping behavior
    container.RegisterSingleDecorator(
        typeof(ICommandHandler<>),
        typeof(LifetimeScopedCommandHandlerProxy<>));
    container.Register<CustomerViewModel>();
