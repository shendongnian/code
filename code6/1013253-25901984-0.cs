    var query = from p in data.Products
                join s in data.ProductStocks on p.ProductID equals s.ProductID
                group s by p into g
                select new {
                    ProductID = g.Key.ProductID,
                    Description = g.Key.Description,
                    Price = g.Key.Price ?? 0,
                    FullPath = g.Key.FullPath,
                    StockLevel = g.Sum(s => s.StockInHand)
                };
