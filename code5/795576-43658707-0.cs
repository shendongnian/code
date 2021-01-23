    var aggDoc = new Dictionary<string,object>
    {
    	{"aggregate" , "originalCollection"},
    	{"pipeline", new []
    		{
    			new Dictionary<string, object> { { "$match" , new BsonDocument() }},
    			new Dictionary<string, object> { { "$out" , "resultCollection"}}
    		}
    	}
    };
    var doc = new BsonDocument(aggDoc);
    var command = new BsonDocumentCommand<BsonDocument>(doc);
    db.RunCommand(command);
