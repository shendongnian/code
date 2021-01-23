    public static class AutofacConfig
    {
        public static void Configure()
        {
            ContainerBuilder builder = new ContainerBuilder();
            ConfigurationBuilder config = new ConfigurationBuilder();
            config.AddXmlFile(@"Config\Autofac.config");
            IContainer container = builder.Build();
            AutofacServiceLocator serviceLocator = new AutofacServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
        }
    }
