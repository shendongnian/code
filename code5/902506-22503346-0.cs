    //storage
    IsolatedStorageSettings.ApplicationSettings["State"] = your string;
     IsolatedStorageSettings.ApplicationSettings.Save();
    
    //retrieval
     if (IsolatedStorageSettings.ApplicationSettings.Contains("State") == true)
     {
     var object= IsolatedStorageSettings.ApplicationSettings["State"] as string;
     //Remove the state now
     IsolatedStorageSettings.ApplicationSettings.Remove("State");
     IsolatedStorageSettings.ApplicationSettings.Save();
     }
