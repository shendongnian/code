    static ViewModelLocator()
    {
        ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
        
        // This will run in design mode, so all your VS design data will come from here
        if (ViewModelBase.IsInDesignModeStatic)
        {
            SimpleIoc.Default.Register<IDataService, Design.DesignDataService>();
        }
        // This will run REAL stuff, in runtime
        else
        {
            SimpleIoc.Default.Register<IDataService, DataService>();
        }
        // You register your classes, so the framework can do the injection for you
        SimpleIoc.Default.Register<MainViewModel>();
        ...
    }
   
