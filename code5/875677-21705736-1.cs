    var query = from r in ds.Tables[0].AsEnumerable()
                group r by r.Field<string>("state") into g
                orderby g.Key
                select new {
                    State = g.Key,
                    Count = g.Count()
                };
