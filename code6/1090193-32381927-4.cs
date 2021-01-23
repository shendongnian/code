    public static void Register(HttpConfiguration config)
            {    
                // Web API configuration and services
                var _container = new UnityContainer();
                DependencyConfiguration.ConfigureContainer(_container);
                config.DependencyResolver = new UnityResolver(_container);
             }
