    if(IsolatedStorageSettings.ApplicationSettings.Contains("State"))
        {
       Image i1=  IsolatedStorageSettings.ApplicationSettings["State"] as Image;
    IsolatedStorageSettings.ApplicationSettings.Remove("State");
                        IsolatedStorageSettings.ApplicationSettings.Save();
        }
