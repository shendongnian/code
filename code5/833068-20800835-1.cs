     public static MongoServer GetConnection()
            {
    
                MongoClient mc = new MongoClient(string.IsNullOrEmpty(ConnectionText) ? System.Configuration.ConfigurationManager.ConnectionStrings["DefaultMongoConnection"].ConnectionString : ConnectionText);
                return mc.GetServer();
            }
