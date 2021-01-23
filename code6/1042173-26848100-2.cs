    var groupedValues = stockValues.GroupBy(n => new  { Year = n.Date.Year })
                           .Select (g => new {
                               Average = g.Average(p => p.Volume), 
                               Year = g.Key.Year
                            })
