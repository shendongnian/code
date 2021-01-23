            //Constructor
            var builder = new ContainerBuilder();
            builder.RegisterSource(new ContravariantRegistrationSource());
            builder.RegisterAssemblyTypes(typeof(IMediator).Assembly).AsImplementedInterfaces(); 
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces();
            // Register Web API controller in executing assembly.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).InstancePerRequest();
            var lazyContainer = new Lazy<IContainer>(() => builder.Build());
            var serviceLocatorProvider = new ServiceLocatorProvider(() => new AutofacServiceLocator(lazyContainer.Value));
            builder.RegisterInstance(serviceLocatorProvider);
            config.DependencyResolver = new AutofacWebApiDependencyResolver(lazyContainer.Value);
            // This should be the first middleware added to the IAppBuilder.
            app.UseAutofacMiddleware(lazyContainer.Value);
            // Make sure the Autofac lifetime scope is passed to Web API.
            app.UseAutofacWebApi(config);
