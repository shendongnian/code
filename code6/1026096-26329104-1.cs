    // using SimpleInjector.Extensions;
    public static void RegisterTypes(IUnityContainer container)
    {
        container.RegisterPerWebRequest<MyContex>();
        container.RegisterOpenGeneric(typeof(IEntityRepository<>), 
            typeof(EntityRepository<>));
        container.RegisterOpenGeneric(typeof(IEntityService<>), 
            typeof(EntityService<>));
    }
