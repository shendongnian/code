     if (IsolatedStorageSettings.ApplicationSettings.Contains("State") == true)
     {
     var object= IsolatedStorageSettings.ApplicationSettings["State"] as Shop;
     //Remove the state now
     IsolatedStorageSettings.ApplicationSettings.Remove("State");
     IsolatedStorageSettings.ApplicationSettings.Save();
     }
