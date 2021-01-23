        public string GetConnectionStringValueFromParent(string key)
        {
            string value = string.Empty;
            try
            {
                const string WEB_CONFIG = "\\Web.config";
                string svcDir = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath;
                DirectoryInfo rootDir = Directory.GetParent(svcDir).Parent;
                string root = rootDir.FullName;
                string webconfigPath = root + WEB_CONFIG;
                ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
                fileMap.ExeConfigFilename = webconfigPath;
                Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
                if (configuration.ConnectionStrings.ConnectionStrings[key].ConnectionString.Length > 0)
                {
                    value = configuration.ConnectionStrings.ConnectionStrings[key].ConnectionString;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return value;
        }
