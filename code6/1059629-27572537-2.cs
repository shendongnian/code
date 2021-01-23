    builder.RegisterSource(new ContravariantRegistrationSource());
            builder.RegisterAssemblyTypes(typeof(IMediator).Assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(HomePageThumbnail).Assembly).AsImplementedInterfaces();
            var lifetimeScope = new Lazy<ILifetimeScope>(() => builder.Build());
            var lazy = new Lazy<IServiceLocator>(() => new AutofacServiceLocator(lifetimeScope.Value));
            var serviceLocatorProvider = new ServiceLocatorProvider(() => lazy.Value);
            builder.RegisterInstance(serviceLocatorProvider);
            
			DependencyResolver.SetResolver(new AutofacDependencyResolver(lifetimeScope.Value));
			app.UseAutofacMiddleware(lifetimeScope.Value);
			app.UseAutofacMvc();
