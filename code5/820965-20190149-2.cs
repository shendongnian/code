    var v = from r in cTable.AsEnumerable()
            let name = r.Field<string>("Name")
            group r by (name ?? "").Replace(",", "") into g
            select new {
              CallType = g.Key,
              Count = g.Count()
            };      
