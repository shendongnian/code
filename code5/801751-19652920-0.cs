    var firstDate = yourDict.First().Key;
    var output = yourDict.GroupBy(e=> (e.Key - firstDate).TotalMinutes / 5)
                         .Select(g=> new {
                                    Date = g.Key,
                                    Avg = g.Average(e=>e.Value)
                                  });
