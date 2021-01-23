    var connectionString = "mongodb://localhost";
    var client = new MongoClient(connectionString);
    var server = client.GetServer();
    var database = server.GetDatabase("testdb"); // "testdb" is the name of the database
    // "Users" is the name of the collection
    var collection = database.GetCollection<Entity>("Users");
    // var searchQuery = Query.EQ("firstname", "Tom"); 
    var cursor = collection.FindAll();
