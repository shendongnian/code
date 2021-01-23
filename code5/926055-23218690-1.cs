    public class ViewModelLocator
    {
		static ViewModelLocator()
	    {
	        ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
	        if (ViewModelBase.IsInDesignModeStatic)
	        {
	            SimpleIoc.Default.Register<IDataService, Design.DesignDataService>();
	        }
	        else
	        {
	            SimpleIoc.Default.Register<IDataService, DataService>();
	        }
	    	// Here you'll register your view models
	        SimpleIoc.Default.Register<MainViewModel>();
	    }  
		//..
	}
