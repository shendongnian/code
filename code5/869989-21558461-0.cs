            string PropertyName
            {
                get
                {
                    var settings = System.IO.IsolatedStorage.IsolatedStorageSettings.ApplicationSettings;
                    if (settings.Contains("valueKeyName"))
                        return (string)settings["valueKeyName"];
                    else
                        return null;
                }
                set
                {
                    var settings = System.IO.IsolatedStorage.IsolatedStorageSettings.ApplicationSettings;
                    if (settings.Contains("valueKeyName"))
                        settings["valueKeyName"] = value;
                    else
                        settings.Add("valueKeyName", value);
                }
            }
