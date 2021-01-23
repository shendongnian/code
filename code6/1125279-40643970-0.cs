    // Get your connection string -- use the URL format as in example below:
    // name="MongoConnectionStr" connectionString="mongodb://localhost/bookstore"
    var connectionString = ConfigurationManager.ConnectionStrings["MongoConnectionStr"].ConnectionString;
    var mongoUrl = MongoUrl.Create(connectionString);
    
    var client = new MongoClient(connectionString);
    
    // Use the Mongo URL to avoid hard-coding the database name.
    var db = new MongoClient(mongoUrl).GetDatabase(mongoUrl.DatabaseName);
    // books below is an IMongoCollection
    var books = db.GetCollection<Book>("Books");
