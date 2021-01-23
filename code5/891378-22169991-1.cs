    var lastOpenedFileSettings = IsolatedStorageSettings.ApplicationSettings;
      if (!lastOpenedFileSettings.Contains("yourSeetingKey"))
           {
             lastOpenedFileSettings.Add("yourSeetingKey", yourSettingValue);
            }
       IsolatedStorageSettings.ApplicationSettings.Save();          
         
   
