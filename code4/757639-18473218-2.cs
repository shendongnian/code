    public static class UnityConfig
    {
        var container = BuildUnityContainer();
        // MVC controllers
        DependencyResolver.SetResolver(new Unity.Mvc3.UnityDependencyResolver(container));
        // WebAPI controllers
        GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
    }
    private static IUnityContainer BuildUnityContainer()
    {
        var container = new UnityContainer();
        // register all your components with the container here
        // you don't need to register controllers
        container.RegisterType<IUsersService, UsersService>();
        ...
        return container;
    }
