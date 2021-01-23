    public static void MongoConnection()
            {
                var connectionString = "mongodb://localhost";
                var mongoClient = new MongoClient(connectionString);
                var mongoServer = mongoClient.GetServer();
                var databaseName = "PointToPoint";
                var db = mongoServer.GetDatabase(databaseName);
                var mongodb = db.GetCollection<MongoDBModel>("OCS.MeterEntity");
                var mongodbQuery = Query<MongoDBModel>.EQ(x => x._id, "4B414D000000011613CD");
                var foundMongoDB = mongodb.FindOne(mongodbQuery);
            }
