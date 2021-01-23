    public static class ConfigCache
    {
        private static Lazy<int> connectionTimeout =
            new Lazy<int>(() => int.Parse(
                ConfigurationManager.AppSettings["connectionTimeout"]));
        public static int ConnectionTimeout
        {
            get { return connectionTimeout.Value; }
        }
    }
