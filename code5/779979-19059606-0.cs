    var results = myCollection
                    .GroupBy(item => new {
                                 Date = item.SaleDate.Date, 
                                 Hour = item.SaleDate.Hour
                    })
                    .Select(x => new {
                                 Date = x.Key.Date,
                                 Hour = x.Key.Hour,
                                 Avvg = x.Average(a => a.Price)
                    });
