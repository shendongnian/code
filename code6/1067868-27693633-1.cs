    var finalList = 
    CombinedList
    .GroupBy(s=>new{s.Year,s.Month})
    .Select(x=>new
               {
                 Year = x.Key.Year,
                 Month = x.Key.Month,
                 Sales = x.Sum(g => Math.Round(Convert.ToDouble(g.Sales), 2)) // Decimal precision    
                }
    ).ToList();
