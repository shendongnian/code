    using (var ctx = new myEntities())
    {
        var pc = ctx.tblPostcodes
            .Where(z => z.Postcode == postcodeOutward)
            .Select(x => new { postcodeId = x.PostcodeID })
            .Single();
    
        int pcId = pc.postcodeId;
    
        var prices = ctx.tblPrices
            .OrderByDescending(x => x.Cost)
            .Where(x => x.PostcodeID == pcId)
            .ToList();
        var items = ctx.tblItems
            .Where(y => y.ItemID < 18)
            .GroupBy(y => y.ItemID)
            .Select(y => new { y, count = y.Count() })
            .ToList();
    
        // Join
        var q = prices
            .Join(items,
                pr => pr.ItemID,
                it => it.ItemID,
                (pr, it) => new
                {
                    pr.ItemID,
                    pr.Cost,
                    pr.SupplierID
                })
            .ToList();
    
        q.Select(x => sb.AppendFormat("ItemId = {0}, Cost = {1}, SupplierId = {2}<hr/>", x.ItemID, x.Cost, x.SupplierID));
    }
