    var results = capData.GroupBy(d => d.ServerName)
                         .Select(g => new { ServerName = g.Key, 
                                            DataGroup = g.GroupBy(d => d.DataDate)
                                                         .Select(gg => new { DataDate = gg.Key, 
                                                                             DailyData = gg.ToList()
                                                                           }
                                          });
