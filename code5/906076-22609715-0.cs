    public static class Global
    {
        private static string path = "";
        public static string GlobalVar
        {
            get 
            { 
                if(String.IsNullOrWhiteSpace(path))
                {
                    path = (string)Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\MyApplication", "DirectoryPath", String.Empty); 
                }
                return path; 
            }
            set
            {
                path = value;
                Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\MyApplication", "DirectoryPath", path,
                                    RegistryValueKind.String);
            }
        }
    }
