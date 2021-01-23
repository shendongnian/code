    if (IsolatedStorageSettings.ApplicationSettings.Contains("key") && 
            IsolatedStorageSettings.ApplicationSettings["key"] != null)
    {
        string GetKey = IsolatedStorageSettings.ApplicationSettings["key"].ToString();
    }
