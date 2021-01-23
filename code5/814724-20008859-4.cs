    public string Title
    {
         if(ViewModelBase.IsInDesignTimeStatic) //Mvvm Light's easy accessor
             return "My Text";
         return ResourceLoader.GetForCurrentView("Strings").GetString("MainView_Title");
    }
