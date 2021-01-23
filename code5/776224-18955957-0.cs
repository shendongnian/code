        void EncryptConnectionStringsIfNecessary()
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ConnectionStringsSection section = configFile.ConnectionStrings;
            if (section != null)
            {
                if (!section.IsReadOnly())
                {
                    if (!section.SectionInformation.IsProtected)
                    {
                        section.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
                        section.SectionInformation.ForceSave = true;
                        ConfigFile.Save(ConfigurationSaveMode.Full);
                    }
                }
            }
        }
