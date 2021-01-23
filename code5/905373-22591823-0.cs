    var adIds = { 1, 2, 4, 5 };
    var result = from c in categoryQuery
                 let searchCount = c.Ads.Count(a => adIds.Contains(a.Id))
                 where searchCount > 0
                 group c by new {c.CategoryParent_Id, c.CategoryParent.Name} into g
                 select new CategoryGetAllBySearchDto
                 {
                     Id = g.Key.CategoryParent_Id,
                     Name = g.Key.Name,
                     SearchCount = searchCount,
                     Ids = g.SelectMany(u => u.Ads)
                            .Where(a => adIds.Contains(a.Id))
                            .Select(a => a.Id)
                 };
