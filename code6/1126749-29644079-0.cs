    var groups = context.Profiles
                         .Where(u => u.CreatedOn.Year == <someYear>)
                         .GroupBy(u => u.CreatedOn.Month)
                                  .Select(g => new {
                                          month = g.Key,
                                          nbUsers = g.Count()
                                          });
