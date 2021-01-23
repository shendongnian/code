    public void SavePlayer()
            {
                IsolatedStorageSettings profile = IsolatedStorageSettings.ApplicationSettings;
    
                string key = string.Format("player{0}", GetCurrentIndex());
                profile.Add(key, player);
                profile.Save();
            }
    
            public object GetPlayer(string Key)
            {
                object obj = null;
    
                IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
    
                if (settings.Contains(Key))
                {
                    obj = settings[Key];
                }
    
                return obj;
            }
    
            public int GetCurrentIndex()
            {
                int index = 1;
    
                IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
    
                if (settings.Contains("CurrentIndex"))
                {
                    index = (int)settings["CurrentIndex"];
                    index++;
                    settings["CurrentIndex"] = index;
                }
                else
                {
                    settings.Add("CurrentIndex", (int)1);
                }
    
                settings.Save();
    
                return index;
            }
