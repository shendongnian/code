    var fListItems = db.FListItems.Include(f => f.FList)
                                  .Include(f => f.Item)
                                  .GroupBy(g => g.FList.Title)
                                  .Select(lg =>
                                   new FListItemsViewModel
                                   {
                                       Title = lg.Key.Title,
                                       ItemStat =lg.Select(x=>new ItemStat
    					                                   {
    					                                       Name = x.Name,
    					                                       NameCount = lg.Count(),
    					                                       NameSum = lg.Sum(w => w.Score),
    					                                       NameAverage = lg.Average(w => w.Score)
    					                                   }).ToList()
                                   });
