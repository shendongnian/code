    MongoClient client = new MongoClient(); // connect to localhost
    MongoServer server = client.GetServer();
    MongoDatabase test = server.GetDatabase("test");
    MongoCollection examples = test.GetCollection("examples");
    
    IMongoQuery query = Query.And(Query.EQ("Activity", 1));         
    UpdateBuilder ub = Update.Unset("two");
    MongoUpdateOptions options = new MongoUpdateOptions {
        Flags = UpdateFlags.Multi
    };
    var updateResults = examples.Update(query, ub, options);
    if (updateResults != null)
    {                
        Console.WriteLine(updateResults);
    }
