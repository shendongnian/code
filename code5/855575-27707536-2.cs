    public static class MongoMock
    {
        public static Mock<MongoServer> CreateMongoServer()
        {
            var serverSettings = new MongoServerSettings
            {
                Servers = new List<MongoServerAddress>
                {
                    new MongoServerAddress("MockServer")
                }
            };
            
            var server = new Mock<MongoServer>(MockBehavior.Strict, serverSettings);
            string message;
            server.Setup(s => s.Settings).Returns(serverSettings);
            server.Setup(s => s.IsDatabaseNameValid(It.IsAny<string>(), out message)).Returns(true);
            
            return server;
        }
        public static Mock<MongoDatabase> CreateMongoDatabase(MongoServer server)
        {
            var databaseSettings = new MongoDatabaseSettings
            {
                GuidRepresentation = GuidRepresentation.Standard,
                ReadEncoding = new UTF8Encoding(),
                ReadPreference = new ReadPreference(),
                WriteConcern = new WriteConcern(),
                WriteEncoding = new UTF8Encoding()
            };
            var database = new Mock<MongoDatabase>(MockBehavior.Strict, server, "MockDatabase", databaseSettings);
            string message;
            database.Setup(db => db.Server).Returns(server);
            database.Setup(db => db.Settings).Returns(databaseSettings);
            database.Setup(db => db.IsCollectionNameValid(It.IsAny<string>(), out message)).Returns(true);
            return database;
        }
        public static Mock<MongoCollection<T>> CreateMongoCollection<T>(MongoDatabase database, string collectionName)
        {
            var collectionSetting = new MongoCollectionSettings();
            var collectionMock = new Mock<MongoCollection<T>>(MockBehavior.Strict, database, collectionName, collectionSetting);
            collectionMock.Setup(x => x.Database).Returns(database);
            collectionMock.Setup(x => x.Settings).Returns(collectionSetting);
            return collectionMock;
        }
        public static Mock<MongoCollection<T>> CreateMongoCollection<T>(string collectionName)
        {
            var server = CreateMongoServer().Object;
            var database = CreateMongoDatabase(server);
            return CreateMongoCollection<T>(database.Object, collectionName);
        }
        public static Mock<MongoCursor<T>> CreateMongoCursor<T>(MongoCollection<T> collection, IEnumerable<T> items = null)
        {
            var cursorMock = new Mock<MongoCursor<T>>(MockBehavior.Strict, collection, null, null, null, null);
            
            if (items != null)
            {
                cursorMock.Setup(c => c.GetEnumerator()).Returns(items.GetEnumerator());
            }
            return cursorMock;
        }
    }
