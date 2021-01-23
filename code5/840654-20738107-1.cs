    // using SimpleInjector.Extensions;
    container.RegisterOpenGeneric(typeof(IRepository<>), typeof(GenericRepository<>));
    container.RegisterOpenGeneric(typeof(IRepository<,>), typeof(GenericRepository<,>));
    container.RegisterOpenGeneric(typeof(ICompoundKeyRepository<,,>), 
        typeof(GenericCompoundKeyRepository<,,>));
