    public static class Settings
    {
        private static string _myName;
        public static string MyName
        {
            get
            {
                if (_myName == null)
                {
                    _myName = ConfigurationManager.AppSettings["MyName"];
                }
                if (_myName == null)
                {
                    throw new Exception("AppSetting 'MyName' is not present in the application configuration file.");
                }
                return _myName;
            }
        }
    }
