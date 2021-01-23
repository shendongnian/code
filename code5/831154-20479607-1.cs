    using System.Collections.Generic;
    class SettingsManager
    {
        Dictionary<string, AcceleromterSettings> settings;
        // contructor for SettingsManager class; a fundamental C# concept
        public SettingsManager()
        {
            LoadSettings();
        }
        // creates new instances of AccelerometerSettings and stores them
        // in a Dictionary<key, value> object for later retrieval. The
        // Dictionary object uses a unique-key to access a value
        // which can be any object.
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
        // Retrieves settings from the Dictionary while hiding
        // specific implementation details.
        public AcceleromterSettings GetSettings(string name)
        {
            AcceleromterSettings setting = null;
            // this method of Dictionary returns a Boolean value indicating
            // whether or not the value retrieval worked. If the Key is found
            // in the dictionary, the 'out' parameter is modified reflect
            // the value, and the method returns true. If the key is not found
            // the 'out' parameter is not modified, and the method returns false.
            if (!settings.TryGetValue(name, out setting))
                throw new ArgumentException(string.Format("Settings not found for settings name {0}", name));
            return setting;
        }
    }
