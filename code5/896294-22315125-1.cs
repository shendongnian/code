    var result = db.Database.SqlQuery<List<object>>(sql, selectColsParam);
    var dynamicResults = result.Select(o => o.AsDynamic()).ToList();
    foreach (dynamic item in dynamicResults)
    {
       // treat as a particular type based on the position in the list
    }
