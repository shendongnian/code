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
    }
