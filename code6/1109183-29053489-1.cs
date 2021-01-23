    public static class Extension
    {
        const string _DefaultBasePath = @"C:\Users\stuyckp\Documents\Visual Studio 2013\Projects\WPF\Interstone";
        private static string _BasePath = null;
        public static string getFullPath(this string relativePath)
        {
            if (relativePath == null) return null;
            string path = BasePath;
            if (!path.EndsWith("\\") && !relativePath.StartsWith("\\")) path += "\\";
            return path + relativePath;
        }
        static private string BasePath
        {
            get
            {
                if (_BasePath != null) return _BasePath;
                try
                {
                    Configuration cs = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    ConfigurationSectionGroup g = cs.SectionGroups["applicationSettings"];
                    ClientSettingsSection s
                        = (from ConfigurationSection section in g.Sections
                            where section is ClientSettingsSection
                            select section).FirstOrDefault() as ClientSettingsSection;
                    _BasePath = s.Settings.Get("BasePath").Value.ValueXml.InnerText;
                }
                catch
                {
                    _BasePath = _DefaultBasePath;
                }
                return _BasePath;
            }
        }
    }
