    public SomeServiceClass(IQueryEntities<UserEntities> users,
        ICommandEntities<EstateModuleEntities> estateModule) { ... }
    public SomeControllerClass(SomeServiceClass service) { ... }
    // Ninject will automatically constructor inject service instance into controller
    // you don't need to pass arguments to the service constructor from controller
