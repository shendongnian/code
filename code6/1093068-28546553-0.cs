    if (File.Exists(configFile))
    {
        var configMap = new ExeConfigurationFileMap { ExeConfigFilename = configFile };
        var config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
        // get the sectionGroup!
        var userSectionGroup = config.GetSectionGroup("userSettings");
        foreach (var userSection in userSectionGroup.Sections)
        {
            // check for a ClientSettingSection
            if (userSection is ClientSettingsSection)
            {
                // cast from ConfigSection to a more specialized type
                var clientSettingSect = (ClientSettingsSection) userSection;
                foreach (SettingElement clientSetting in clientSettingSect.Settings)
                {
                    Debug.WriteLine(String.Format("{0}={1}", clientSetting.Name, clientSetting.Value.ValueXml.InnerText ));
                }
            }
 
        }
    }
