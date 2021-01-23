    using System;
    using System.Configuration;
    namespace WebTest
    {
        public static class CachedSettings
        {
            public static string MyData;
            public static CachedSettings()
            {
                MyData = ConfigurationManager.AppSettings["MyData"];
            }
        }
    }
