    var databaseClient = new MongoClient(DatabaseConnectionString);
    var server = databaseClient.GetServer();
    var database = server.GetDatabase("YourDatabase");
    var collection = database.GetCollection<YourObject>("YourObjects");
    
    var subdoc = collection.AsQueryable().First(o => o.name == "hello").subdoc;
    var subdocName = subdoc.name;
    
    public class YourObject
    {
        public string name;
        public OtherObject subdoc;
    }
    
    public class OtherObject
    {
        public string name;
    }
