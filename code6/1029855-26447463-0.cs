        static void Main(string[] args)
        {
            string userNameWithoutEncryption = ConfigurationManager.AppSettings["username"];
            EncryptAppSettings("appSettings");
            string userNameWithEncrytionApplied = ConfigurationManager.AppSettings["username"];
        }
 
 
        private static void EncryptAppSettings(string section)
        {
            Configuration objConfig = ConfigurationManager.OpenExeConfiguration(GetAppPath() + "AppKeyEncryption.exe");
            AppSettingsSection objAppsettings = (AppSettingsSection)objConfig.GetSection(section);
            if (!objAppsettings.SectionInformation.IsProtected)
            {
                objAppsettings.SectionInformation.ProtectSection("RsaProtectedConfigurationProvider");
                objAppsettings.SectionInformation.ForceSave = true;
                objConfig.Save(ConfigurationSaveMode.Modified);
            }
        }
 
        private static string GetAppPath()
        {
            System.Reflection.Module[] modules = System.Reflection.Assembly.GetExecutingAssembly().GetModules();
            string location = System.IO.Path.GetDirectoryName(modules[0].FullyQualifiedName);
            if ((location != "") && (location[location.Length - 1] != '\\'))
                location += '\\';
            return location;
        }
