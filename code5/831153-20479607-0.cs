    using System.Collections.Generic;
    class SettingsManager
    {
        Dictionary<string, AcceleromterSettings> settings;
        public SettingsManager()
        {
            LoadSettings();
        }
        void LoadSettings()
        {
            settings = new Dictionary<string, AcceleromterSettings>();
            AcceleromterSettings horizontal = new AcceleromterSettings();
            horizontal.AttributeOne = 101;
            horizontal.AttributeTwo = 532;
            horizontal.AttributeThree = 783;
            settings.Add("Horizontal", horizontal);
            AcceleromterSettings vertical = new AcceleromterSettings();
            vertical.AttributeOne = 50;
            vertical.AttributeTwo = 74;
            vertical.AttributeThree = 99;
            settings.Add("Vertical", vertical);
        }
        public AcceleromterSettings GetSettings(string name)
        {
            AcceleromterSettings setting = null;
            if (!settings.TryGetValue(name, out setting))
                throw new ArgumentException(string.Format("Settings not found for settings name {0}", name));
            return setting;
        }
    }
