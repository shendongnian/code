    return r.Find()
            .GroupBy(x => new { x.ProductID, x.BuyerID })
            .Select(x => new ProductCount
                         {
                             ProductID = x.Key.ProductID,
                             Quantity = x.Count()
                         })
            .ToList();
