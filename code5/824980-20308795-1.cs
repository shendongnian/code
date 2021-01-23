    IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
    
              
                settings["test"] = urlText.Text;
                settings.Save();
