      public static void RegisterComponents()    
            {
        		var container = new UnityContainer();
                container.RegisterType<ITestService, TestService>();
                DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            }
