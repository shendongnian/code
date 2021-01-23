    public void ApplicationBootstrap()
    {
        IContainer container = StructureMapCoreSetup.Initialise();
        container.Configure(c =>
        {
            c.IncludeRegistry<DefaultRegistry>();
        });
    }
