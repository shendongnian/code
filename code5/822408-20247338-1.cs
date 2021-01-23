        public static IUnityContainer Initialise()
        {
          var container = BuildUnityContainer();
          GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
          DependencyResolver.SetResolver(new UnityDependencyResolver(container));
    
          return container;
        }
    
     private static IUnityContainer BuildUnityContainer()
        {
          var container = new UnityContainer();
          RegisterTypes(container);
          return container;
        }
    
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IAgencyResolver, AgencyByNameResolver>("ByName");
            container.RegisterType<IAgencyResolver, AgencyByCdeCodeResolver>("ByCode");
            container.RegisterType<IAgencyRepository, AgenciesRepository>();            
        }
