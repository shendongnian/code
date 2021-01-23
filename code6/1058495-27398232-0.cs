     var fListItems = db.FListItems.Include(f => f.FList)
                                   .Include(f => f.Item)
                                   .GroupBy(g => g.FaveList.Title)
                                   .Select(lg =>
                                       new FListItemsViewModel
                                           {
                                               Title = lg.Key,
                                               ItemStat = lg.GroupBy(x => x.Item.Name)
                                                            .Select(x => new ItemStat
                                                                {
                                                                    Name = x.Key,
                                                                    NameCount = x.Count(),
                                                                    NameSum = x.Sum(w => w.Score),
                                                                    NameAverage = x.Average(w => w.Score)
                                                                }).ToList()
                                                });
