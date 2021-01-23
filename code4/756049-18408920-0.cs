    private void CheckAppLaunchStatus()
    {
        // Application settings
        readonly IsolatedStorageSettings _settings = IsolatedStorageSettings.ApplicationSettings;
        if (_settings.Contains("AppLunchTimes"))
        {
            value = (int) _settings["AppLunchTimes"];
    
            if (value % 2 == 0)
                Deployment.Current.Dispatcher.BeginInvoke(() => MessageBox.Show("Would you like to buy the application?", "Trial Version", MessageBoxButton.OKCancel));
    
            _settings["AppLunchTimes"] = value++;
        }
        else
            _settings.Add(key, 1);
    }
