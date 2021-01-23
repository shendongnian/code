    var results = myCollection.GroupBy(i => i.SaleDate.Date)
                              .Select(g => new {Date = g.Key, Average = g.Average(a => a.Price) });
    foreach(var result in results)
    {
           Console.WriteLine("{0}  {1}", result.Date, result.Average);
    }
