    var results = myCollection.Where(i => i.SaleDate.Date == theDate)
                              .GroupBy(i => i.SaleDate.Hour)
                              .Select(g => new {Hour = g.Key, Average = g.Average(a => a.Price) });
    foreach(var result in results)
    {
       var hourStart = TimeSpan.FromHours(result.Hour);
       var hourEnd = TimeSpan.FromHours(result.Hour + 1);
       Console.WriteLine("{0:hh\:mm} - {1:hh\:mm}  {1}", hourStart, hourEnd, result.Average);
    }
    
