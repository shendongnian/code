    // inner select
    var subquery = DetachedCriteria.For<ItemEnityMaxDate>()
        .SetProjection(Projections.Property("Id"));
    // the ItemEntity
    var query = session.CreateCriteria<ItemEntity>()
        .Add(Subqueries.PropertyIn("Id", subquery));
    var list = query.List<ItemEntity>();
