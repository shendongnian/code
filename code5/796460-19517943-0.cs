    var categoryTotals = company.Saleses
                .GroupBy (c => c.Category)
                .Select (
                   g => 
                      new  
                      {
                         Category = g.Key, 
                         Total = g.Sum(s => s.Amount)
                      }
                );
    foreach(var categoryTotal in categoryTotals)
    {
         Console.WriteLine(string.Format("Category: {0}, Total: {1}", 
             categoryTotal.Category, categoryTotal.Total.ToString()));
    }   
