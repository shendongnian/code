    public class SettingsWrapper
    {
        Dictionary<string, object> settings = new Dictionary<string, object>();
        // TODO populate with initial values from server
        public bool UpdateSetting<T>(string name, T value)
        {
            // only update if the initial value is ready, and if the new value is different
            if (settings.ContainsKey(name) && (T)settings[name] != value)
                CallWebService();
        }
    }
