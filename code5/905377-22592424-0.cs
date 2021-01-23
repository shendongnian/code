    var adIds = { 1, 2, 4, 5 };
    var result = categoryQuery.Where(c => c.Ads.Any(a => adIds.Contains(a.Id)))
                            .Select(c => new 
                            { 
                                c.CategoryParent_Id, 
                                c.CategoryParent.Name,
                                Ids = c.Ads.Where(a => adIds.Contains(a.Id)).Select(a => a.Id).AsEnumerable()
                            })
                            .ToList()
                            .GroupBy(c => new {c.CategoryParent_Id, c.Name})
                            .Select(g => new CategoryGetAllBySearchDto
                             {
                                 Id = g.Key.CategoryParent_Id,
                                 Name = g.Key.Name,
                                 Ids = g.SelectMany(u => u.Ids).AsEnumerable()
                             })
                             .ToList();
