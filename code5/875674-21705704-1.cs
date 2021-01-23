    var query = ds.Tables[0].AsEnumerable()
        .GroupBy(dr1 => dr1.Field<string>("state"))
        .Select(g => new {
            State = g.Key
        ,   Count = g.Count()
        })
        .OrderBy(p => p.State)
        .ToList();
