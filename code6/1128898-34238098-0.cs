        static void MongoGoNow()
        {
            IMongoCollection<ClassA> collection = db.GetCollection<ClassA>(Collection.MsgContentColName);
            var result = TestFind(collection);
            result.GetAwaiter().GetResult();
            //What's next???
        }
        static async Task TestFind(IMongoCollection<ClassA> MyCollection)
        {
            var filter = new BsonDocument();
            var count = 0;
            using (var cursor = await MyCollection.FindAsync(filter))
            {
                while (await cursor.MoveNextAsync())
                {
                    var batch = cursor.Current;
                    foreach (var document in batch)
                    {
                        // process document
                        count++;
                    }
                }
            }       
