       string ApplicationDataFolder
            {
                get
                {
                    return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                            Assembly.GetExecutingAssembly().GetName().Name);
                }
            }
            string UserSettingFilePath
            {
                get
                {
                    return Path.Combine(ApplicationDataFolder, "Setting.xml");
                }
            }
     [Serializable]
        public class AppSetting
        {
            public AppSetting()
            {
               //default instantiation 
            }
      
            public int? CurrentUserId
            {
                get;
                set;
            }
    
    
        }
        enter code he
