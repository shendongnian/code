    var subquery = DetachedCriteria.For<TimeBlock>("timeBlock")
        .CreateAlias("timeBlock.ProgramItems", "programItems")
        .SetProjection(Projections.Min("timeBlock.StartTime"))
        .Add(Restrictions.EqProperty("programItems.Id", "root.Id"));
    // ORDER BY built from Subquery
    var orderByMin = new Order(Projections.SubQuery(subquery), true); // true is ASC
    var list = session
        .CreateCriteria<ProgramItem>("root")
        .AddOrder(orderByMin)
        .SetMaxResults(10)    // paging... if needed
        .List<ProgramItems>();
