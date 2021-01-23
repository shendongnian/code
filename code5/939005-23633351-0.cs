    var dates = Enumerable.Range(0, (DateTime.Now - startDate).Days + 1)
                          .Reverse()
                          .Select(i => DateTime.Now.Date.AddDays(-i))
                          .ToArray();
    var dailyReadings =
       list.SelectMany(inspection => dates.Select(d => 
          new
          {
             Date = d,
             Reading = inspection.Readings
                                 .OrderBy(r => r.DateTaken)
                                 .LastOrDefault(reading => reading.DateTaken <= d) 
          }));
    var worstCases =
       dailyReadings.GroupBy(dr => dr.Date)
                    .Select(g => new
                                 {
                                    Date = g.Key,
                                    Status = g.Max(i => i.Reading == null
                                                         ? Status.Ok
                                                         : i.Reading.Status)
                                 });
