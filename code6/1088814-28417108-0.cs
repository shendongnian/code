    SimpleIoc.Default.Register<ViewModel1>();
    SimpleIoc.Default.Register<ViewModel2>();
    public ViewModel ViewModel1Instance
    {
        get
        {
            return ServiceLocator.Current.GetInstance<ViewModel1>();
        }
    }
    public ViewModel ViewModel2Instance
    {
        get
        {
           return ServiceLocator.Current.GetInstance<ViewModel2>();
        }
    }
