    var bsonlist = new List<BsonDocument>();
    foreach (var obj in list)
    {
        bsonlist.Add(BsonDocument.Parse(obj));
    }
    
    var myCollection = database.GetCollection("MyStuff");
    var doc = BsonArray.Create(bsonlist);
    myCollection.InsertBatch(doc);
