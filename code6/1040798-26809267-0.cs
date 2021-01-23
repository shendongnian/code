        public void Initialize()
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            if (!localSettings.Values.ContainsKey(FirstRunSettingName))
            {
                localSettings.Values.Add(FirstRunSettingName, false);
            }
            localSettings.Values.Add(SettingNames.DataFilename, "todo.data.xml");
        }
        public bool IsFirstRun()
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            if (localSettings.Values.ContainsKey(FirstRunSettingName))
            {
                return (bool)localSettings.Values[FirstRunSettingName];
            }
            else
            {
                return true;
            }
        }
