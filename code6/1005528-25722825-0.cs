        var query = Query.And(Query.EQ("Domain", "DOMXYZ"), Query.EQ("hostname", "HOSTXYZ"), Query.EQ("service", "RAM_USAGE"));
        
       //Gets the latest record from MongoDB matching given fileds
        var bsonCursor = GetMongoDatabase().GetCollection<YourClassName(YourMongoDBCollectionName).Find(query).SetSortOrder(SortBy.Descending("timestamp")).SetLimit(1);
        
        foreach (YourClassName objYourClassName in bsonCursor)
        {
        	//Do your task
        }
