    public static void RegisterTypes(Container container)
    {
        container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
        container.Register<MyContex>(Lifestyle.Scoped);
        container.Register(typeof(IEntityRepository<>), typeof(EntityRepository<>));
        container.Register(typeof(IEntityService<>), typeof(EntityService<>));
    }
