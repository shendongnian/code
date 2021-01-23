    IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
    
                if (!settings.Contains("test"))
                {
                    settings.Add("test", urlText.Text);
                }
                else
                {
                    settings["test"] = urlText.Text;
                }
                settings.Save(); 
