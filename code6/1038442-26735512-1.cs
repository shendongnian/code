    if (!IsolatedStorageSettings.ApplicationSettings.Contains("recent_images"))
    {
        IsolatedStorageSettings.ApplicationSettings.Add("recent_images", YOUR_LIST);        
    }
    IsolatedStorageSettings.ApplicationSettings.Save();    
