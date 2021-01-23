    var query = ds.Tables[0].AsEnumerable()
                  .GroupBy(r => r.Field<string>("state"))
                  .OrderBy(g => g.Key)
                  .Select(g => new { State = g.Key, Count = g.Count() })
                  .ToList();
