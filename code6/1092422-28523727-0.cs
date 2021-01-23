    public void Post(List<Entity> entities)
    {
        var client = new MongoClient("mongodb://localhost:27017");
        var server = client.GetServer();
        var db = server.GetDatabase("Test");
        foreach(var entity in entities)
        {
            var collection = db.GetCollection<Entity>("Entities");
            collection.Save(entity);
        }
    }
