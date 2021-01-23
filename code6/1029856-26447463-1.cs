        private static void DecryptAppSettings(string section)
        {
            Configuration objConfig = ConfigurationManager.OpenExeConfiguration(GetAppPath() + "AppKeyEncryption.exe");
            AppSettingsSection objAppsettings = (AppSettingsSection)objConfig.GetSection(section);
            if (objAppsettings.SectionInformation.IsProtected)
            {
                objAppsettings.SectionInformation.UnprotectSection();
                objAppsettings.SectionInformation.ForceSave = true;
                objConfig.Save(ConfigurationSaveMode.Modified);
            }
        }
