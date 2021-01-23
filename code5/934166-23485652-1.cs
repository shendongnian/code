    var criteria = DetachedCriteria.For<Person>()
    // instead of this
    // .CreateAlias("Vehicles","vehicle", JoinType.InnerJoin)
    // we will use subquery
    .Add(Subqueries.PropertyIn("ID", vehicles));
    // Wrong to use this approach at all
    //.SetResultTransformer(new DistinctRootEntityResultTransformer())
    .SetMaxResults(pageSize)
    .SetFirstResult((page - 1) * pageSize)
