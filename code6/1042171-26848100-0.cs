    var groupedValdues = stockValues.GroupBy(t => new  { Year = n.Date.Year })
                           .Select (g => new {
                               Average = g.Average (p => p.Volume), 
                               Year = g.Key.Year
                            })
