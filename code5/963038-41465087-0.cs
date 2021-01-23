    public IEnumerable<string> GetMongoFields(string collectionName)
            {
                var connectionString = ConfigurationManager.ConnectionStrings[DbConfig.GetMongoDb()].ConnectionString;
                var databaseName = MongoUrl.Create(connectionString).DatabaseName;
                MongoClient client = new MongoClient(connectionString);
                var server = client.GetServer();
                var db = server.GetDatabase(databaseName);
    
                var collection = db.GetCollection<BsonDocument>(collectionName);
                var list = collection.FindAll().ToList();
    
               yield return list.ToJson();
            }
