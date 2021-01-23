        `
        /// <summary>
        /// set config, if key is not in file, create
        /// </summary>
        /// <param name="key">Nome do parâmetro</param>
        /// <param name="value">Valor do parâmetro</param>
        public static void SetConfig(string key, string value)
        {
            var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = configFile.AppSettings.Settings;
            if (settings[key] == null)
            {
                settings.Add(key, value);
            }
            else
            {
                settings[key].Value = value;
            }
            configFile.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
        }
        /// <summary>
        /// Get key value, if not found, return null
        /// </summary>
        /// <param name="key"></param>
        /// <returns>null if key is not found, else string with value</returns>
        public static string GetConfig(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }`
