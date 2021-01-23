    IsolatedStorageSettings stores data in key value pare and to save it use Save():
              
                 var lastOpenedFileSettings = IsolatedStorageSettings.ApplicationSettings;                     
                                        if (!lastOpenedFileSettings.Contains("yourSeetingKey"))
                                        {
                                            lastOpenedFileSettings.Add("yourSeetingKey", yourSettingValue);
                                        }
              IsolatedStorageSettings.ApplicationSettings.Save();
                   
    To retrive setting value cast it into required datatype:
            
                IsolatedStorageSettings lastOpenedFileSettings = IsolatedStorageSettings.ApplicationSettings;
                                    string lastOpenedFileId = (string)lastOpenedFileSettings["yourSeetingKey"];
