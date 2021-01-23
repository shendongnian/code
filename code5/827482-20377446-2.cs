    public static class AppSettings
    {
        public static string ConnString
        {
            get
            {
                return ConfigurationManager
                    .ConnectionStrings["train_debConnectionString"]
                    .ConnectionString
            }
        }
    }
