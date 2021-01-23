    var rawQuery = Query.EQ("ExtendedProperties.Context.DeclaringTypeName", "EndpointConfig");
    var query = new List<IMongoQuery>();
    query.Add(rawQuery);
    
    var rawResult = collection.Find(rawQuery).ToList();
