    MongoClient client = new MongoClient(); // connect to localhost
    MongoServer server = client.GetServer();
    MongoDatabase test = server.GetDatabase("test");
    MongoCollection examples = test.GetCollection("examples");
    
    string id = "52bc958ca45026c2ff24f90b";
    IMongoQuery query = Query.EQ("_id", ObjectId.Parse(id));        
    UpdateBuilder ub = Update.Set("Name", "George");
    WriteConcernResult updatedBook = examples.Update(query, ub);
