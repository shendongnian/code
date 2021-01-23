        static void MongoGoNow()
        {
            IMongoCollection<ClassA> collection = db.GetCollection<ClassA>(Collection.MsgContentColName);
            TestFind(collection).GetAwaiter().GetResult();
            //What's next???
        }
