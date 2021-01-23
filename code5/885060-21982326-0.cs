    var query = session.QueryOver<MyEntity>()
        // force the collection inclusion
        .Fetch(x => x.Collection1).Eager
        .Fetch(x => x.Collection2).Eager
        ...
        // force the relations inclusion
        .Fetch(x => x.SubEntity1).Eager
        .Fetch(x => x.SubEntity2).Eager
        ...
        // paging
        .Skip(x)
        .Take(y);
    var list = query
         .List<MyEntity>();
