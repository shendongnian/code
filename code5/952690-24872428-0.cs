    public static class Program
    {
        public static void Main(string[] args)
        {
            var client = new MongoClient("mongodb://localhost");
            var server = client.GetServer();
            var database = server.GetDatabase("test");
            var collection = database.GetCollection("test");
        
            collection.Drop();
            collection.Insert(new BsonDocument("_id", 1));
            collection.Insert(new BsonDocument("_id", 2));
        }
    }
