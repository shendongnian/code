    public static void RegisterComponents()
    		{
    			var container = new UnityContainer();
    			
    			// register all your components with the container here
    			// it is NOT necessary to register your controllers
    
    			// Conventional registration mapping
    			// container.RegisterType<IHomeService, HomeService>();
    
    			// This will register all types with a ISample/Sample naming convention 
    			container.RegisterTypes(
    				AllClasses.FromLoadedAssemblies(),
    				WithMappings.FromMatchingInterface,
    				WithName.Default);			
    			
    			GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
    		}
