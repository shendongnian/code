    public MainMenuViewModel MainMenuViewModel
    {
        get
        {
            return ServiceLocator.Current.GetInstance<MainMenuViewModel>();
        }
    }
