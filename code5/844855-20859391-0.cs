    // But everything in the Query
    IMongoQuery mongoQuery = query.Or(ids);
    // Add Queryattributes if there
    if (queryattributes.Count > 0)
    {
        mongoQuery = mongoQuery.And(queryattributes);
    }
    
    var result = collection.FindAs<Datapoint>(mongoQuery);
