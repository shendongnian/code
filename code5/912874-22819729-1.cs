    List<Item> combined = (from t in items1
                           join r in items2 on new { t.Id, t.Code } equals new { r.Id, r.Code }
                           select new Item
                           {
                               Id = t.Id,
                               Code = t.Code,
                               Orders = t.Orders.Union(r.Orders).ToList()
                           }).ToList();
