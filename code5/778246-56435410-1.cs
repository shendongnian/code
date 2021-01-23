    //struggled a lot to figure out this
    using MongoDB.Bson;
    using MongoDB.Driver;
    namespace Mongo_AWS
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
    //Mention cert file in connection string itself or put at your executable location
                string connectionString = @"mongodb://user:pwd@localhost:9999/?ssl=true&ssl_ca_certs=C:\Users\sivaram\Downloads\my.pem";
                MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
                
                //Disable certificate verification, if it is not issued for you
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
