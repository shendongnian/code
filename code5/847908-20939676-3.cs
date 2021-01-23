    class MyObjectContext : ObjectContext
    {
        public MyObjectContext()
            : base(MyObjectContext.connectionString)
        { }
    
        /// <summary>
        /// the connection string id in the config
        /// </summary>
        const string connectionStringID = "dbCon";
    
        /// <summary>
        /// gets the connection string
        /// </summary>
        static string connectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings[connectionStringID].ConnectionString
            }
        }
    }
