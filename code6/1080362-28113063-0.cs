    try
    {
         var prop1= Settings.Default.prop1;
    }
    catch (Exception ex)
    {
        var userSettingsLocation =
          Path.Combine(Environment.ExpandEnvironmentVariables(
            "%USERPROFILE%"), "AppData","Local", "MyApp");
        if (Directory.Exists(userSettingsLocation))
        {
             if (ex.InnerException is System.Configuration.ConfigurationException)
             {
                 var settingsFile = (ex.InnerException as ConfigurationException).Filename;
                 File.Delete(settingsFile);
                 System.Windows.Forms.Application.Restart();
             }
        }
    }
