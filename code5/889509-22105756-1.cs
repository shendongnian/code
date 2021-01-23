       private void InitializeContainer()
        {
            var oldProvider = FilterProviders.Providers.Single(f => f is FilterAttributeFilterProvider);
            FilterProviders.Providers.Remove(oldProvider);
            Container.Register(Component.For<IWindsorContainer>().Instance(this.Container));
            Container.Install(new BootstrapInstaller());
            registerCustom();
            Container.Install(new WebWindsorInstaller());
            var provider = new WindsorFilterAttributeFilterProvider(this.Container);
            FilterProviders.Providers.Add(provider);
            DependencyResolver.SetResolver(new WindsorDependencyResolver(ServiceFactory.Container));
            // register WebApi controllers
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), new WindsorHttpControllerActivator(ServiceFactory.Container));
        }
