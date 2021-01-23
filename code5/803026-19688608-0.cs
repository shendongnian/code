    IEnumerable<Keyword> query = db.Keywords;
    if(String.IsNullOrEmpty(alpha))
        query = query.Where(k => k.starts == alpha)
    // need to change from Keyword collection to anonymous type collection
    var query2 = query.GroupBy(k => k.Keyword)   
                      .Select(g => new {
                                       word = g.Key,
                                       Counter = g.Count()
                                       }
                             );
