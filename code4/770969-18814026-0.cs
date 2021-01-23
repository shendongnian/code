    var tableBPredicate = PredicateBuilder.True<tableB>();
    foreach (var filter in filters)
    {
        /* build up tableB conditions here */
        tableBPredicate = tableBPredicate.And(p => p.Column1 == filter.Column1);
        tableBPredicate = tableBPredicate.And(p => p.Column2 => filter.Column2);
    }
	
	var tableBQuery = tableB.AsExpandable().Where(tableBPredicate);
	
    var query = from b in tableBQuery
        join a in tableA
        on new
        {
            ProductId = b.ProductId,
            UserId = b.UserId
        }
        equals
        new
        {
            ProductId = a.ProductId,
            UserId = a.UserId
        }
        where a.ProductId == 6544
        select a;
    return query.ToList();
