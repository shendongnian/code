    var project = new BsonDocument {
        {
            "$project",
            new BsonDocument()
                .Add( "item", 1 )
                .Add( "category", 1 )
                .Add( "mobileView", 1 )
                .Add( 
                    "totalView",
                    new BsonDocument()
                        .Add( "$add", new BsonArray {
                            "$mobileView", "$webView"
                        })
                )
        } 
    };
    var sort = new BsonDocument {
        {
            "$sort",
            new BsonDocument {
                { "totalView", -1 }
            }
        }
    };
    var pipeline = new[] { project, sort };
    var results = collection.Aggregate(pipeline);
