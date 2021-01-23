    var fListItems = db.FListItems.Include(f => f.FList)
                                  .Include(f => f.Item)
                                  .GroupBy(g => new { g.Item.Name, g.FList.Title })
                                  .Select(lg =>
                                   new FListItemsViewModel
                                   {
                                       Title = lg.Key.Title,
                                       ItemStat =lg.Select(x=> new ItemStat
                                       {
                                           Name = x.Key.Name,
                                           NameCount = x.Count(),
                                           NameSum = x.Sum(w => w.Score),
                                           NameAverage = x.Average(w => w.Score)
                                       }).ToList()
                                   });
