    var groupedfListItems = db.FListItems.Include(f => f.FList)
                                     .Include(f => f.Item)
                                     .Select(lg =>
                                     new TestViewModel
                                     { 
                                         Name = lg.Item.Key,
                                      })
                                     .GroupBy(g => g.Name);
