    var output = items.GroupBy(i => i.Id)
                      .Select(g => new Item() 
                              {
                                  Id = g.Key
                                  Orders = g.SelectMany(i => i.Orders)
                                            .ToList()
                              });
