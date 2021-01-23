    public static void RegisterNinject(HttpConfiguration configuration)
            {
                // Set Web API Resolver
                configuration.DependencyResolver = new NinjectDependencyResolver(Bootstrapper.Kernel);
            
            }
