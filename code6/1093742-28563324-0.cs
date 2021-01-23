    public static class AppSettings 
    {
        private static void LoadSettings 
        {
            // This is where you would call the DB and populate the cache
        }
        public static string AppName
        {
            get
            {
                if (Cache["appname"] == null)
                    LoadSettings();
                return Cache["appname"];
            }
        }
    }
