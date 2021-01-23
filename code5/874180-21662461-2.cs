    var client = new MongoClient("mongodb://localhost");
    var server = client.GetServer();
    
    var database = server.GetDatabase("test"); // "test" is the name of the database
    var collection = database.GetCollection("myCollection");
    var results = collection.Find(Query.EQ("Name", Textbox1.Text));
    if (results.Count() == 0)
    {
        Console.WriteLine("no matches");
        // or MessageBox.Show(...)
    }
