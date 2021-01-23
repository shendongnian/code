    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    
        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
    
            // register all your components with the container here
            // e.g. container.RegisterType<ITestService, TestService>();
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            var connectionFactory = new OrmLiteConnectionFactory(connectionString, SqlServerDialect.Provider);
            var connectionFactoryConstructor = new InjectionConstructor(connectionFactory);
            container.RegisterType<ConfigManagement.Domain.Core.IParameterValueRepository, ConfigManagement.DAL.Core.ParameterValueRepository>(connectionFactoryConstructor);
    
            return container;
        }
    }
