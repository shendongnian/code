    var client = new MongoClient(); // connect to localhost
    var server = client.GetServer();
    var test = server.GetDatabase("test");
    var examples = test.GetCollection("examples");
    
    var query = Query.EQ("Activity", 1);         
    var ub = Update.Unset("two");
    var options = new MongoUpdateOptions {
        Flags = UpdateFlags.Multi
    };
    var updateResults = examples.Update(query, ub, options);
    if (updateResults != null)
    {                
        Console.WriteLine(updateResults);
    }
