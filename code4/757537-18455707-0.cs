    public static T GetSetting<T>(string settingKey, T defaultValue)
    {
        Mutex mutex = new Mutex(false, "MyAppSettingsLock");
        mutex.WaitOne();
        T result;
        if (IsolatedStorageSettings.ApplicationSettings.Contains(settingKey))
            result = (T)IsolatedStorageSettings.ApplicationSettings[settingKey];
        else
            result = defaultValue;
        mutex.ReleaseMutex();
        return result;
    }
    public static void SetSetting<T>(string settingKey, T value)
    {
        Mutex mutex = new Mutex(false, "MyAppSettingsLock");
        mutex.WaitOne();
        IsolatedStorageSettings.ApplicationSettings[settingKey] = value;
        IsolatedStorageSettings.ApplicationSettings.Save();
        mutex.ReleaseMutex();
    }
