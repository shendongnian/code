    public string GetString() 
    {
        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("nl-NL");
        Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("nl-NL");
    
        // CommonResources is the name of my resource file   
        ResourceManager resManager = new ResourceManager(typeof(CommonResources));   
        return resManager.GetString("LoginLabel",CultureInfo.CurrentCulture); 
    }
