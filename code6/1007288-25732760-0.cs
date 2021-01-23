    MongoClient client = new MongoClient(); // connect to localhost
    MongoServer server = client.GetServer();
    var db = server.GetDatabase("foo");
    var col = db.GetCollection<RawBsonDocument>("multiArr");
    // Query = {'Keys':{$elemMatch:{$elemMatch:{$in:['carrot']}}}}
    BsonDocument query = new BsonDocument{ 
        "Keys", new BsonDocument {
          "$elemMatch", new BsonDocument {
              "$elemMatch", new BsonDocument {
                  "$in", new BsonArray().Add("carrot")
              }
          }
        }
    };
    col.Find(query);
