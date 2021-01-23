    var query = db.RPTINQUIRies.Where(c => c.CONCOM == concom);
    if (engineer != null)
    {
        query = query.Where(c => c.LOPER == engineer);
    }
    query = query.OrderByDescending(c => c.CREATION_DATE);
