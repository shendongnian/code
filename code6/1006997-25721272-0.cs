    var query = Client.Cypher
        .Match("(n:User)-[r]-(m:User)")
        .Where((UserEntity n) => n.Id == 1)
        .Return((n, r, m) => new
        {
            N = n.As<UserEntity>(),
            M = m.As<UserEntity>(),
            R = r.As<RelationshipInstance<object>>()
        });
    var res = query.Results;
    foreach (var item in res.ToList())
        Console.WriteLine("({0})-[:{1}]-({2})", item.N.Id, item.R.TypeKey, item.M.Id);
