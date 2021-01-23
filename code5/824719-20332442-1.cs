    var list = DB.Where(c => c.Status.Equals("active"))
                 .Select(c => new BsonDocument("name", c.Name))
                 .ToList();
    const string connectionString = "mongodb://localhost";
    var client = new MongoClient(connectionString);
    MongoServer server = client.GetServer();
    MongoDatabase database = server.GetDatabase("test");
    var collection = database.GetCollection("salesppl");
    collection.InsertBatch(list);
