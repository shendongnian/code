    private static void Main()
    {
        var container = BuildContainer();
        Application.Run(container.Resolve<IFormMain>());
    }
    public static IUnityContainer BuildContainer()
    {
        var currentContainer = new UnityContainer() ;
        currentContainer.RegisterType<IFormMain, FormMain>();
        // note: registering types could be moved off to app config if you want as well
        return currentContainer;
    }
