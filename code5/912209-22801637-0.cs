    var items = (from i in catalog.Items
                 select new Item
                 {
                     Id = i.Id,
                     Relation = i.Relation.Where(r => r.Type != "external").ToArray(),
                 }).ToArray();
