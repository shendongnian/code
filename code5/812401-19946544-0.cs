    public sealed class SettingsHelper
    {
        private static readonly SettingsHelper _Instance = new SettingsHelper();
        private NameValueCollection _SettingsSection = null;
        // ...
    
        private SettingsHelper()
        {
            LoadSettings()
        } 
        public void LoadSettings()
        {
            _SettingsSection = new NameValueCollection(ConfigurationManager.AppSettings);           
        }
        .....
    }
