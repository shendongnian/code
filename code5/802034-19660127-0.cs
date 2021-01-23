    var sales = (from sale in db.Sales
                 where sale.DateOfSale > startDate && sale.DateOfSale < endDate
                 group sale by new {sale.ItemID, sale.EstimatedShipping} into g
                 select new
                 {
                     ItemID = g.Key.ItemID,
                     Estimate = g.Key.EstimatedShipping,
                     ActualShipCosts = g.Select(gSales => gSales.ActualShipping).ToList()
                 }).ToList();
