    var client = new MongoClient();
    var database = client.GetServer().GetDatabase("test");
    var parentCollection = database.GetCollection<Parent>("Parent");
    
    var parent = parentCollection.AsQueryable().FirstOrDefault(p => p.subdoc.Any(f => f.key == 5));
    
    if (parent != null)
    {
        var fooList = parent.subdoc.Where(f => f.key == 5);
        foreach (var foo in fooList)
        {
            foo.deletedAt = DateTime.UtcNow;
        }
    }
    
    parentCollection.Save(parent);
