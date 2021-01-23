    var newlist = obj2List.GroupBy(x => x.code)
                          .Select(g => new
                          {
                              Code = g.First().code,
                              Name = g.First().name,
                              Amount = g.Sum(x => x.amount)
                          });
