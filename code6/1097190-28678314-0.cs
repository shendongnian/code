    if (ViewModelBase.IsInDesignModeStatic)
    {
      SimpleIoc.Default.Register<IMyService, StubServiceImplementation>();
    }
    else
    {
    SimpleIoc.Default.Register<IMyService, RealServiceImplementation>();
    }
