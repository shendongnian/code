    var query = ds.Tables[0].AsEnumerable()
                .GroupBy(r => new
                {
                    state = r.Field<string>("state"),
                    name = r.Field<string>("name"),
                })
                .Select(grp => new
                {
                    name = grp.Key.name,
                    state = grp.Key.state,
                    Count = grp.Count()
                })
                .OrderBy(o => o.state)
                .ToList();
