     public static void ReadCollectionDataUsingBson(string collectionName, string databaseName)
        {
            MongoDatabase database = CreateDatabase(databaseName);
            MongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>(collectionName);
            foreach (BsonDocument document in collection.FindAll())
            {
                foreach (string name in document.Names)
                {
                    BsonElement element = document.GetElement(name);
                    Console.WriteLine("{0}: {1}", name, element.Value);
                }
                Console.WriteLine();
            }
        }
