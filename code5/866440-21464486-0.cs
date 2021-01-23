    // If you decide later you need other dependencies like IUnityContainer, you can just set 
    // it in your constructor and Unity will give it to you automagically through the power 
    // of Dependency Injection
    // public ViewAccountsViewModel(IRegionManager regionManager, IUnityContainer unityContainer)
    public ViewAccountsViewModel(IRegionManager regionManager)
    {
        this.regionManager = regionManager;
    }
