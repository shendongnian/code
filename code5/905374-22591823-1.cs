    var adIds = { 1, 2, 4, 5 };
    var result = from c in categoryQuery
                 where c.Ads.Any(a => adIds.Contains(a.Id))
                 group c by new {c.CategoryParent_Id, c.CategoryParent.Name} into g
                 select new CategoryGetAllBySearchDto
                 {
                     Id = g.Key.CategoryParent_Id,
                     Name = g.Key.Name,
                     SearchCount = g.SelectMany(u => u.Ads)
                                    .Where(a => adIds.Contains(a.Id))
                                    .Count(),
                     Ids = g.SelectMany(u => u.Ads)
                            .Where(a => adIds.Contains(a.Id))
                            .Select(a => a.Id)
                 };
