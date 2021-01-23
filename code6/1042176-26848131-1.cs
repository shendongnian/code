    var groupedResults = stockValues.GroupBy(m => m.Date.Year)
                                   .Select(g => new {
                                      year = g.Key,
                                      avg = g.Average(s => s.Volume)
                                   });
    
    
    foreach (var res in groupedResults)
       Console.WriteLine("{0} average : {1}", res.year, res.avg));
