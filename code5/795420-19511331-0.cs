    if(!IsolatedStorageSettings.ApplicationSettings.Contains("KeyName"))
    {
    IsolatedStorageSettings.ApplicationSettings["KeyName"]=your object;
    IsolatedStorageSettings.ApplicationSettings.Save();
    }
