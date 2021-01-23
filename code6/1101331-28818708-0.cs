    ThemeService singletonService = null;
    private ThemeService GetThemeService() 
    {
        if (singletonService == null) 
        {
            singletonService = new ThemeService(Mvx.Resolve<IMvxJsonConverter>(), Mvx.Resolve<IMvxResourceLoader>());
        }
        return singletonService;
    }
    protected override void InitializeFirstChance()
    {
        Mvx.RegisterSingleton<IDroidThemeService>(GetThemeService);
        Mvx.RegisterSingleton<IThemeService>(GetThemeService);
        base.InitializeFirstChance();
    }
