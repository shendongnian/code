    // Resource path
    private string strResourcesPath= Application.StartupPath + "/Resources";
    // String to store current culture which is common in all the forms
    // This is the default startup value
    private string strCulture= "en-US";
    // ResourceManager which retrieves the strings
    // from the resource files
    private static ResourceManager rm;
    
    // This allows you to access the ResourceManager from any form
    public static ResourceManager RM
    { 
      get 
      { 
       return rm ; 
       } 
    }
    private void GlobalizeApp()
    {
        SetCulture();
        SetResource();
        SetUIChanges();
    }
    private void SetCulture()
    {
        // This will change the current culture
        // This way you can update it without restarting your app (eg via combobox)
        CultureInfo objCI = new CultureInfo(strCulture);
        Thread.CurrentThread.CurrentCulture = objCI;
        Thread.CurrentThread.CurrentUICulture = objCI;
        
    }
    private void SetResource()
    {
        // This sets the correct language file to use
        rm = ResourceManager.CreateFileBasedResourceManager
            ("resource", strResourcesPath, null);
    
    }
    private void SetUIChanges()
    {
        // This is where you update all of the captions
        // eg:
        label1.Text=rm.GetString("label1");
    }
