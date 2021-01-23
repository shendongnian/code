    {
        //code for initialization
        //for localhost connection there is no need to specify the db server url and port.
        var client = new MongoClient("mongodb://localhost:27017/"); 
        var db = client.GetDatabase("TestDb"); 
        Collection = db.GetCollection<T>("testCollection"); 
     }
    //Code for db operations
    {
       
       //The connection happens here.
       var collection = db.Collection;
       //Your find operation
       var model = collection.Find(Builders<Model>.Filter.Empty).ToList();
       //Your insert operation
       collection.InsertOne(Model);
    }
