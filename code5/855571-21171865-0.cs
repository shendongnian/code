    public MongoServer GetMockedMongoDbServer()
    {
        var serverSettings = new MongoServerSettings
        {
            Servers = new List<MongoServerAddress>
            {
                new MongoServerAddress("unittest")
            }
        };
        var server = new MongoServer(serverSettings);
        return server;
    }
    public static Mock<MongoCollection<T>> CreateMockCollection<T>(MongoDatabase database, string name)
    {
        var collectionSetting = new MongoCollectionSettings();
        var m = new Mock<MongoCollection<T>>(database, name, collectionSetting);
        m.Setup(x => x.Database).Returns(database);
        m.Setup(x => x.Settings).Returns(collectionSetting);
        return m;
    }
    public MongoDatabase GetMockedMongoDb(MongoServer server)
    {
        var databaseSettings = new MongoDatabaseSettings()
        {
            GuidRepresentation = GuidRepresentation.Standard,
            ReadEncoding = new UTF8Encoding(),
            ReadPreference = new ReadPreference(),
            WriteConcern = new WriteConcern(),
            WriteEncoding = new UTF8Encoding()
        };
        var database = new Mock<MongoDatabase>(server, "db_name", databaseSettings);
        var message = String.Empty;
        database.Setup(db => db.Settings).Returns(databaseSettings);
        database.Setup(db => db.IsCollectionNameValid(It.IsAny<string>(), out message)).Returns(true);
        var c = CreateMockCollection(database.Object, "MyCollectionName");
        database.Setup(f => f.GetCollection("MyCollectionName")).Returns(c.Object);
        return database.Object;
    }
    public IMongoDbContext GetMockedMongoContext()
    {
        var server = GetMockedMongoDbServer();
        var database = GetMockedMongoDb(server);
        var mongoDbContext = new Mock<IMongoDbContext>();
        mongoDbContext.Setup(x => x.GetMongoDatabase()).Returns(database);
        return mongoDbContext.Object;
    }
