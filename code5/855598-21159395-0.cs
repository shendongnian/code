    IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
    // txtInput is a TextBox defined in XAML.
    if (!settings.Contains(key))
     {
         settings.Add(key, value);  // adding new value
         settings.Save();
     }
