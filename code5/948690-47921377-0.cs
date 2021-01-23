    foreach(var _Assembly in AppDomain.CurrentDomain.GetAssemblies())
    {
        foreach(var _Type in _Assembly.GetTypes())
        {
            if(_Type.Name == "Settings" && typeof(SettingsBase).IsAssignableFrom(_Type))
            {
                var settings = (ApplicationSettingsBase)_Type.GetProperty("Default").GetValue(null, null);
                if(settings != null)
                {
                    settings.Upgrade();
                    settings.Reload();
                    settings.Save();
                }
            }
        }
    }
