    private static void ChangeWebConfig(string validationKey, string decryptionKey, string webConfigPath)
    {
        ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
        configFileMap.ExeConfigFilename = webConfigPath;
        System.Configuration.Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
        MachineKeySection section = (MachineKeySection)config.GetSection("system.web/machineKey");
        section.ValidationKey = validationKey;
        section.DecryptionKey = decryptionKey;
        config.Save();
    }
