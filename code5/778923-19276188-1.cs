    Configuration AppConfiguration =
        ConfigurationManager.OpenMappedExeConfiguration(
            new ExeConfigurationFileMap {ExeConfigFilename = "AppSettings.config"}, ConfigurationUserLevel.None);
    var settings = AppConfiguration.AppSettings.Settings;
    // access
    var name = settings["Name"].Value;
    var age = settings["Age"].Value;
    var hobbies = settings["Hobbies"].Value.Split(new[]{';'});
    // modify
    settings["Age"].Value = "50";
    // store (writes the physical file)
    AppConfiguration.Save(ConfigurationSaveMode.Modified);
