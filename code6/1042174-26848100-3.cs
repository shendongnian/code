     var groupedValues = stockValues.GroupBy(n => n.Date.Year)
                       .Select (g => new {
                           Average = g.Average(p => p.Volume), 
                           Year = g.Key
                        });
