    var url = new MongoUrl("mongodb://localhost");
    var client = new MongoClient(url);
    var server = client.GetServer();
    var database = server.GetDatabase("test");
    var collection = database.GetCollection<Record>("records");
    
    var query = Query<Record>.EQ(i => i.Athlete.Id, "123456789101112131415161");
    var result = collection.Find(query).ToList();
