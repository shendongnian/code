    public static bool DesignMode
    {
        get { return DesignerProperties.GetIsInDesignMode(new DependencyObject()); }
    }
    static ApplicationViewModel()
    {
        if (!DesignMode)
        {
            Configuration = Configuration.LoadConfigurationDocument();
        }
    }
