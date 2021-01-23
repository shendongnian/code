    var query = ds.Tables[0].AsEnumerable()
                  .GroupBy(x=>x.Field<string>("state"))
                  .Select( g => new{
                       state = g.Key,
                       count = g.Count()
                  });
