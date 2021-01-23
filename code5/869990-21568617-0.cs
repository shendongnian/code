     var Iso_settings = System.IO.IsolatedStorage.IsolatedStorageSettings.ApplicationSettings;   
    if (!Iso_settings.Contains("yourDataKey"))
        {
          Iso_settings.Add("yourDataKey", yourDataValue);
          Iso_settings.Save()//This will save your data in isolated storage.
        }
