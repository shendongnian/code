    var query = Client.Cypher
        .Match("(n:User)-[r*1..4]-(m:User)")
        .Where((UserEntity n) => n.Id == 1)
        .Return((n, r, m) => new
        {
            N = n.As<Node<UserEntity>>(), //<-- Node<T>
            M = m.As<Node<UserEntity>>(), //<-- Node<T>
            R = r.As<IEnumerable<RelationshipInstance<object>>>()
        });
    foreach (var item in res.ToList())
        foreach (var relationshipInstance in item.R)
            Console.WriteLine("({0})-[:{1}]-({2})", item.N.Data.Id, relationshipInstance.TypeKey, item.M.Data.Id);
