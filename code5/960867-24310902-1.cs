    public class AppConfigWrapper : IConfigurationWrapper {
        
        public string GetValue(string key) {
            return ConfigurationManager.AppSettings(key);
        }
        public bool HasKey(string key) {
           return ConfigurationManager.AppSettings.AllKeys.Select((string x) => x.ToUpperInvariant()).Contains(key.ToUpperInvariant());
        }
    }
