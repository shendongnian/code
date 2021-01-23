    Events x = null;
    Receivers t = null;
    // Similar to LINQ, with COUNT
    var subquery2 = QueryOver.Of<Receivers>(() => t)
        .Where(() => t.SOMETHING == x.SOMETHING) // The JOIN clause between Receivers and Events
        .ToRowCountQuery();
    var result2 = Session.QueryOver<Events>(() => x)
        .Where(Restrictions.Disjunction()
            .Add(() => x.Owner.ID == 1)
            .Add(() => x.EVType.ID == 123)
            .Add(Subqueries.WhereValue(0).Lt(subquery2))
        )
        .Select(Projections.Group(() => x.StartDate))
        .List<DateTime>();
    // With EXIST
    var subquery = QueryOver.Of<Receivers>(() => t)
        .Where(() => t.SOMETHING == x.SOMETHING) // The JOIN clause between Receivers and Events
        .Select(t1 => t1.ID);
    var result = Session.QueryOver<Events>(() => x)
        .Where(Restrictions.Disjunction()
            .Add(() => x.Owner.ID == 1)
            .Add(() => x.EVType.ID == 123)
            .Add(Subqueries.WhereExists(subquery))
        )
        .Select(Projections.Group(() => x.StartDate))
        .List<DateTime>();
