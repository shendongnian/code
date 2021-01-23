    var client = new MongoClient();
    var server = client.GetServer();
    var db = server.GetDatabase("MyDb");
    var myDb = new MyDatabase(db);
    myDb.Objects.Find();
