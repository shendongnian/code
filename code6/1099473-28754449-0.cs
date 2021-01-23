    public class Settings
    {
        private Dictionary<string, object> _settings = new Dictionary<string, object>();
        public void Add(string key, object value)
        {
            _settings.Add(key, value);
        }
        public T Get<T>(string key)
        {
            if (!_settings.ContainsKey(key))
                return default(T);
            if (_settings[key] is T)
                return (T)_settings[key];
            try
            {
                return (T)Convert.ChangeType(_settings[key], typeof(T));
            }
            catch (InvalidCastException)
            {
                return default(T);
            }
        }
    }
