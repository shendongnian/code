    var results = data.GroupBy(g=> Gender = g.agentsGender)
                      .Select(g=> new 
                                  { 
                                     gender = g.Key  
                                     years = g.GroupBy(y=> y.Date.Year)
                                              .OrderBy(y=> y.Key)
                                              .Select(y=> y.Sum(y.funds))
                                              .ToArray()
                                  })
                      .ToArray();
