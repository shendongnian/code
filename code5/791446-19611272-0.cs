    public static class appdata
    {
    
        static ResourceManager rm = new ResourceManager("Resources.Resource", System.Reflection.Assembly.Load("App_GlobalResources"));
     static     CultureInfo ci =  default(CultureInfo);
    
    
        private static isValidChassisTableAdapter _isvalidchassis = null;
        private static SG_FORMTableAdapter _sgform = null;
        private static settingTableAdapter _setting = null;
        private static IsInRoleTableAdapter _Role = null;
        private static tblaccountsTableAdapter _accounts = null;
        private static tblloginhistoryTableAdapter _AppEvents = null;
    
        private static configTableAdapter _AppConfig = null;
        public static configTableAdapter AppConfig
        {
            get
            {
                if (_AppConfig == null)
                {
                    _AppConfig = new configTableAdapter();
                }
    
                return _AppConfig;
            }
        }
    public static string ApplicationContext
        {
            get { return ConfigurationManager.AppSettings.Get("ApplicationContext"); }
        }
    }
