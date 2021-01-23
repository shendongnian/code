    var v = from r in cTable.AsEnumerable()
            let v = r.Field<string>("Name")
            group r by (v ?? "").Replace(",", "") into g
            select new {
              CallType = g.Key,
              Count = g.Count()
            });      
