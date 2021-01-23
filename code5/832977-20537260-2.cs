    // the most outer SELECT
    var query = session.QueryOver<Request>();
    query.WithSubquery
        // our Request ID is IN(...
        .WhereProperty(r => r.ID)
        .In(successSubquery);
    
    var list = query
        .List<Request>();
