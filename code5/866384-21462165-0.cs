    using MongoDB.Driver.Builders;
    List<IMongoQuery> queries = new List<IMongoQuery>();
    if (request.CultureId != null && request.CareerId != null) {
      queries.Add(
        Query<Person>.ElemMatch<IDependent>(p => p.Dependents,
          q => Query.And(
            q.EQ(x => x.CareerId, request.CareerId),
            q.EQ(x => x.CultureId, request.CultureId))));
    }
    // ... etc
    // Final Query: 
    var query = Query.And(queries);
