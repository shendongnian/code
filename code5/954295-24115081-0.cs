    public class LocalSettingsHelper
    {
        public static void Save<T>(string key, T value)
        {
            ApplicationData.Current.LocalSettings.Values[key] = value;
        }
    
        public static T Read<T>(string key)
        {
            if (ApplicationData.Current.LocalSettings.Values.ContainsKey(key))
            {
                return (T)ApplicationData.Current.LocalSettings.Values[key];
            }
            else
            {
                return default(T);
            }
        }
    
        public static bool Remove(string key)
        {
            return ApplicationData.Current.LocalSettings.Values.Remove(key);
        }
    }
