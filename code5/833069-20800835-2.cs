     public static MongoDatabase GetDatabase(string database = "")
            {
                if (string.IsNullOrEmpty(database))
                {
                    return GetConnection().GetDatabase(string.IsNullOrEmpty(DatabaseText) ? System.Configuration.ConfigurationManager.AppSettings.Get("MongoDbName") : DatabaseText);
                }
                else
                {
                    return GetConnection().GetDatabase(database);
                }
            }
