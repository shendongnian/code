    public interface IConfigurationReader
    {
        string GetAppSetting(string key);    
    }
    public class ConfigurationReader : IConfigurationReader
    {
        public string GetAppSetting(string key)
        {
            return ConfigurationManager.AppSettings[key].ToString();
        }
    }
