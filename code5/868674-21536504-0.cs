    {
        public string connectionString;
        public GlobalClass() 
        {
            connectionString = System.Configuration.ConfigurationManager.AppSettings.Get("ConnString");
        }
    }
}
