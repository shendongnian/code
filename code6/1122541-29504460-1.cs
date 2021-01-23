    static async Task CreateIndex()
    {
        var client = new MongoClient();
        var database = client.GetDatabase("db");
        var collection = database.GetCollection<Hamster>("collection");
        await collection.Indexes.CreateOneAsync(Builders<Hamster>.IndexKeys.Ascending(_ => _.Name));
    }
