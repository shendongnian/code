    var average2 = myCollection.GroupBy(item => new 
                   { 
                       Date = item.SaleDate.Date, 
                       Hour = item.SaleDate.Hour,
                       DateTime = item.SaleDate })
                           .Select(item2 => new 
                           { 
                               Date = item2.Key.DateTime, 
                               Average = item2.Average(a => a.Price) 
                           });
