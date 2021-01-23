    .SetSeries(new Series
             {
                Type = ChartTypes.Pie,
                Name = "Browser share",
                Data = new Data(new object[] { browers.Select(b => new {Name =b.GetValue(0), Y = b.GetValue(1) }).ToArray() })
             });
                
           
