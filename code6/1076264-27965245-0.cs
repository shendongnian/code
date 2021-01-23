    // The URL for this service can be configured during runtime. 
    // If it is null or empty it should not be resolved.
    container.Register(Component.For<ITestService>()
        .UsingFactoryMethod((kernel, context) => 
        {
            if (!string.IsNullOrEmpty(SiteInformation.PublishUrl))
                return ServiceFactory.CreateService<ITestService>(SiteInformation.PublishUrl));
            return kernel.Resolve<INullTestService>();
        })
        .Named(PublicationServiceComponent)
        .LifeStyle.Transient);
