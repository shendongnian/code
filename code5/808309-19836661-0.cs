    public class IsolateStorageStore
    {
        /// <summary>
        /// The iosolated settings store.
        /// </summary>
        private readonly IsolatedStorageSettings isolatedStorageSettings = IsolatedStorageSettings.ApplicationSettings;
        public T ReadValue<T>(string key)
        {
            return isolatedStorageSettings.Contains(key) ? (T)isolatedStorageSettings[key] : default(T);
        }
        public void WriteValue<T>(string key, T value)
        {
            if (isolatedStorageSettings.Contains(key))
            {
                isolatedStorageSettings[key] = value;
            }
            else
            {
                isolatedStorageSettings.Add(key, value);
            }
        }
    }
