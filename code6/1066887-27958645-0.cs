    var entityIds = session.CreateCriteria<Entity>()
        .CreateAlias("EntityList", "el")
        .AddOrder(Order.Asc("el.Name"))
        .SetProjection(Projections.Id)
        .List<int>();
    
    var entities = session.CreateCriteria<Entity>()
        .Add(Expression.In(Projections.Id, entityIds))
        .SetFetchMode("EntityList", FetchMode.Eager)
        .List<Entity>();
    
    // resort again
    return entityIds.Select(id => entities.First(e => e.Id == id)).ToList();
