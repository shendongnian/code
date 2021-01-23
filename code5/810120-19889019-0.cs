    // on Windows 8
    // input value
    string userName = "John";
            
    // persist data
    ApplicationData.Current.LocalSettings.Values["userName"] = userName;
    // read back data
    string readUserName = ApplicationData.Current.LocalSettings.Values["userName"] as string;
    // on Windows Phone 8
    // input value
    string userName = "John";
            
    // persist data
    IsolatedStorageSettings.ApplicationSettings["userName"] = userName;
    // read back data
    string readUserName = IsolatedStorageSettings.ApplicationSettings["userName"] as string;
