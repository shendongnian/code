    var hits = pageHitList.Select(hit => 
                                      new { 
                                          Hit = hit, 
                                          Grouping = x.RequestTime.RoundUp(TimeSpan.FromMinutes(30))
                                      })
              .GroupBy(x => x.Grouping);
    var averages = hits.Select(hit => new { 
                                          hit.Key, 
                                          Average = hit.Average(x => x.Hit.PageResponseTime) 
                                      });
