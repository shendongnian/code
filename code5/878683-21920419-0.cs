    private static object readSetting(string key)
    {
        var container = ApplicationData.Current.LocalSettings.CreateContainer("defaultContainer",ApplicationDataCreateDisposition.Existing);
        if (container == null)
        {
           return null;
        }
        return Container.Values[key]
    }
