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
                throw new KeyNotFoundException(string.Format("Cannot find setting {0}", key));
            if (_settings[key] is T)
                return (T)_settings[key];
            try
            {
                return (T)Convert.ChangeType(_settings[key], typeof(T));
            }
            catch (InvalidCastException)
            {
                throw new InvalidCastException(string.Format("Unable to cast setting {0} to {1}", key, typeof(T)));
            }
        }
    }
