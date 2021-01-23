    var average = myCollection.GroupBy(item => item.SaleDate.Date)
                      .Select(item2 => new 
                      { 
                          Date = item2.Key, 
                          Average = item2.Average(a => a.Price) 
                      });
