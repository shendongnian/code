    using MongoDB.Driver;
    using MongoDB.Bson;
    using MongoDB.Driver.Builders;
    var client = new MongoClient("mongodb://localhost");
    var coll = client.GetServer().GetDatabase("local").GetCollection("test1");
    var query = Query.EQ("C", "Red");
    var doc = coll.FindOne(query);
    var value = doc["C"];
