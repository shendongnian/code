      public class MySqlDbConfiguration: DbConfiguration 
    {
        public MySqlDbConfiguration()
        {
            SetDefaultConnectionFactory(new MySqlConnectionFactory());
            SetProviderServices(MySqlProviderInvariantName.ProviderName, new MySqlProviderServices());
            RegisterFactoryIfRequired();
        }
        private static void RegisterFactoryIfRequired()
        {
            string dataProvider = @"MySql.Data.MySqlClient";
            string dataProviderDescription = @".Net Framework Data Provider for MySQL";
            string dataProviderName = @"MySQL Data Provider";
            string dataProviderType =
                @"MySql.Data.MySqlClient.MySqlClientFactory, MySql.Data, Version=6.8.3.0, Culture=neutral, PublicKeyToken=c5687fc88969c44d";
            bool addProvider = true;
            var dataSet = ConfigurationManager.GetSection("system.data") as DataSet;
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                if ((row["InvariantName"] as string) == dataProvider)
                {
                    // it is already in the config, no need to add.
                    addProvider = false;
                    break;
                }
            }
            if (addProvider)
                dataSet.Tables[0].Rows.Add(dataProviderName, dataProviderDescription, dataProvider, dataProviderType);
            // test it
            var factory = DbProviderFactories.GetFactory("MySql.Data.MySqlClient");
        }
       
    }
