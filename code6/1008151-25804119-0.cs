    static void EncryptConfig()
    {
        // Encrypt config for ClickOnce deploys on first run
        // ClickOnce deploys config into 2 dirs, so the parent dir is traversed to encrypt all
        if (ApplicationDeployment.IsNetworkDeployed)
        {
            // Get paths
            Assembly asm = Assembly.GetExecutingAssembly();
            string exeName = Path.GetFileName(asm.Location);
            string configName = exeName + ".config";
            DirectoryInfo parentPath = Directory.GetParent(Directory.GetCurrentDirectory());
            // Protect config files
            foreach (DirectoryInfo dir in parentPath.GetDirectories())
            {
                foreach (FileInfo fil in dir.GetFiles())
                {
                    if (fil.Name == configName)
                    {
                        ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
                        fileMap.ExeConfigFilename = fil.FullName;
                        Configuration config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
                        ProtectSection(config, "connectionStrings");
                        config.Save(ConfigurationSaveMode.Modified);
                    }
                }
            }
        }
    }
    private static void ProtectSection(Configuration config, string sectionName)
    {
        ConfigurationSection section = config.GetSection(sectionName);
        if (section != null)
        {
            if (!section.SectionInformation.IsProtected)
            {
                section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
            }
            section.SectionInformation.ForceSave = true;
        }
        else
            Tools.LogWarning("Section {1} not found in {0}.",config.FilePath, sectionName);
    }
