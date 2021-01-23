        /// <summary>
        /// Returns an Entity Connectionstring ready to be used in a EF6 contructor
        /// </summary>
        /// <param name="connectionString">plain connectionstring</param>
        /// <returns>entity connectionstring</returns>
        public string GetEntityConnectionString(string connectionString)
        {
            var entityBuilder = new EntityConnectionStringBuilder();
            entityBuilder.Provider = "System.Data.SqlClient";
            entityBuilder.ProviderConnectionString = connectionString;
            // -- WARNING --
            // Check your app config and set the appropriate DBModel (do not just let this be YourDBModel) 
            entityBuilder.Metadata = @"res://*/DB.YourDBModel.csdl|res://*/DB.YourDBModel.ssdl|res://*/DB.YourDBModel.msl";
            var ret = entityBuilder.ToString();
            return ret;
        }
