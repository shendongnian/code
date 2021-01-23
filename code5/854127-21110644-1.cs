    var data = db.database_BWICs.AsQueryable();
    if (!string.IsNullOrEmpty(query.name))
    {
        var ids = query.name.Split(',');
        data = data.Where(c => c.Name != null && ids.Contains(c.Name)));
    }
    //etc.
    
    if (query.price_type != null)
    {
         var ids = query.price_type.Split(',');
         data = data.Where(c => ids.Contains(c.Type));
    }
