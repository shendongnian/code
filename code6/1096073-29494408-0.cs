    public static ICrossPlatformInterface CrossPlatformFactory
    {
        get { return Factory._getCrossPlatformFactory; }
        set { Factory._getCrossPlatformFactory = value; }
    }
    public void SetCrossPlatformFactory(ICrossPlatformInterface crossPlatformFactory)
    {
        CrossPlatformFactory = crossPlatformFactory;
    }
