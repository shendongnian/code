    public static class ScopeManager
    {
        private static NameValueCollection _appSettings;
        
        public static NameValueCollection AppSettings
        {
            get
            {
                if (_appSettings.IsNull())
                {
                    //GET FROM DATABASE, CACHE OR SOMEWHERE ELSE
                }
    
                return _appSettings;
            }
        }
    }
