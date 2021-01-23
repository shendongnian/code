    public static void Main (string[] args)
        {
            var connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("test");  
            string text = System.IO.File.ReadAllText(@"records.JSON");
            var document = BsonSerializer.Deserialize<BsonDocument>(text);
            var collection = database.GetCollection<BsonDocument>("test_collection");
            await collection.InsertOneAsync(document);
            
        }
