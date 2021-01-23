    container.RegisterType<IUserContext, AspNetUserContext>();
    container.RegisterType( 
        typeof(IIntegrationController<,>), 
        typeof(IntegrationControllerDispatcher<,>));
    container.RegisterType(typeof(Repository<>), typeof(Repository<>));
