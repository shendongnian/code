    var conn = new MongoClient("mongodb://the.server.url").GetServer().GetDatabase("TestDB");
    
    if(conn.CollectionExists("Queue")) {
    	conn.DropCollection("Queue");
    }
    
    conn.CreateCollection("Queue", CollectionOptions
    	.SetCapped(true)
    	.SetMaxSize(100000)
    	.SetMaxDocuments(100)
    	.SetAutoIndexId(true)
    );
    
    //Insert an empty document as without this 'cursor.IsDead' is always true
    var coll = conn.GetCollection("Queue");
    coll.Insert(
    	new BsonDocument(new Dictionary<string, object> {
    		{ "PROCESSED", true },
    		{ "Date", DateTime.UtcNow },
    		{ "X", "test" }
    	}), WriteConcern.Unacknowledged
    );
    
    //Create query based on latest document id
    BsonValue lastId = BsonMinKey.Value;
    var query = coll.Find(Query.GT("_id", lastId))
    	.SetFlags(QueryFlags.AwaitData | QueryFlags.NoCursorTimeout | QueryFlags.TailableCursor);
    
    var cursor = new MongoCursorEnumerator<BsonDocument>(query);
    
    while(true) {
        if(cursor.MoveNext()) {
            string.Format(
                "{0:yyyy-MM-dd HH:mm:ss} - {1}",
                cursor.Current["Date"].ToUniversalTime(),
                cursor.Current["X"].AsString
            ).Dump();
        } else if(cursor.IsDead) {
            "DONE".Dump();
            break;
        }
    }
