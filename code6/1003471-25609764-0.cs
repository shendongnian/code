    // group by PortfolioId
    // HAVING for outer 'p.ID'
    var subquery = QueryOver.Of(() => q)
        .SelectList(list => list
            .SelectGroup(() => q.PortfolioId)
            .SelectMax(() => q.Id)
        )
        .Where(Restrictions.EqProperty( // HAVING
            Projections.Property(() => p.Id),
            Projections.Max(() => q.Id)))
         ;
    // now select the list of p.Id, prefiltered by above subquery
    var filter = QueryOver.Of(() => p)
        .WithSubquery.WhereExists(subquery)
        .Select(Projections.Property(() => p.Id));
    // finally the result as a set of q entities
    // ready for paging
    var result = session.QueryOver(() => q)
        .WithSubquery
            .WhereProperty(() => q.Id)
            .In(filter)
        // .Skip(0) -- paging could be used
        // .Take(25)
        .List()
        ;
