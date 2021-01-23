    if(!IsolatedStorageSettings.ApplicationSettings.Contains("State"))
    {
     IsolatedStorageSettings.ApplicationSettings["State"] = Image Object;
                    IsolatedStorageSettings.ApplicationSettings.Save();
    }
