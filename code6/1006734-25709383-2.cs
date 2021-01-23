    using System.Configuration;
    using System.Web.Configuration;
    Configuration config = WebConfigurationManager.OpenWebConfiguration(null);
    if (config.AppSettings.Settings.Count > 0)
    {
        KeyValueConfigurationElement customSetting = config.AppSettings.Settings["DocumentDirectory"];
        if (customSetting != null)
        {
            string directory = customSetting.Value;
        }
    }
