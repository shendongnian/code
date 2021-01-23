    var query = Client.Cypher
        .Match("(n:User)-[r*1..4]-(m:User)")
        .Where((UserEntity n) => n.Id == 1)
        .Return((n, r, m) => new
        {
            N = n.As<UserEntity>(),
            M = m.As<UserEntity>(),
            R = r.As<IEnumerable<RelationshipInstance<object>>>() //<-- IEnumerable<T>
        });
    var res = query.Results;
    foreach (var item in res.ToList())
        foreach (var relationshipInstance in item.R)
            Console.WriteLine("({0})-[:{1}]-({2})", item.N.Id, relationshipInstance.TypeKey, item.M.Id);
