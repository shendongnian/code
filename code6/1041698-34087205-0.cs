        public static bool PropertiesHasKey(string key)
        {
            foreach (SettingsProperty sp in Properties.Settings.Default.Properties)
            {
                if (sp.Name == key)
                {
                    return true;
                }
            }
            return false;
        }
