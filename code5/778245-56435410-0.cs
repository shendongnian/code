    internal class Program
    {
        private static void Main(string[] args)
        {
            string connectionString = @"mongodb://user:pwd@localhost:9999/?ssl=true&ssl_ca_certs=C:\Users\sivaram\Downloads\my.pem";
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            settings.VerifySslCertificate = false;
            MongoClient client = new MongoClient(settings);
            IMongoDatabase database = client.GetDatabase("test");
            IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>("numbers");
            System.Collections.Generic.List<BsonDocument> temp = collection.Find(new BsonDocument()).ToList();
            BsonDocument docToInsert = new BsonDocument { { "sivaram-Pi", 3.14159 } };
            collection.InsertOne(docToInsert);
        }
    }
}
