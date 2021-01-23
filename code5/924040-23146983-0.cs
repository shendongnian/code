    private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            //Set DependencyResolver
	        DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            return container;
        });
     
