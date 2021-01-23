    // the below outer query, has essential feature
    // ALIAS name "outer"
    // and this is used here, in the "subquery"
    var maxDateQuery = DetachedCriteria.For<MyEntity>("myEntity")
        .SetProjection(
            Projections.ProjectionList()
            .Add(Projections.GroupProperty("MyId"))
            .Add(Projections.Max("MyDate"))
            )
            .Add(Restrictions.EqProperty(
            Projections.Max("MyDate"),
            Projections.Property("outer.MyDate")) // compare inner MAX with outer current
            )
            .Add(Restrictions.EqProperty("MyId", "outer.MyId")) // inner and outer must fit
        ;
    // here ... the "outer" is essential, because it is used in the subquery
    var list = session.CreateCriteria<Contact>("outer")
        .Add(Subqueries.Exists(maxDateQuery))
        ... // e.g. paging
        .List<MyEntity>();
