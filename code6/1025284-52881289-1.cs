    IQueryable<Object> query = db.Set("TableName");
    // Filter against "query" variable below...
    List<Object> result = query.ToList();
    // or use further dynamic Linq
    IQueryable<Object> query = db.Set("TableName").Where("t => t.TableFilter == \"MyFilter\"");
    
