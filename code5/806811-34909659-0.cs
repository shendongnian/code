    // Object --> JSON 
    using System.Web.Extensions;
    using System.Web;
    using System.Web.Script.Serialization;
    JavaScriptSerializer js = new JavaScriptSerializer();
    string json = js.Serialize(poco);    // poco is ur class object
    
    //JSON --> BSON
    MongoDB.Bson.BsonDocument document = MongoDB.Bson.Serialization.BsonSerializer.Deserialize<BsonDocument>(json);
