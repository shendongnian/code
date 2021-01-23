    var sales = (from sale in db.Sales
             where sale.DateOfSale > startDate && sale.DateOfSale < endDate
             select new
             {
                 ItemID = sale.ItemID
                 Estimate = sale.EstimatedShipping
                 ActualShipCosts = sale.ActualShipping
             }).ToList();
    var groupedSales = (from sale in sales
             group sale by new {sale.ItemID, sale.EstimatedShipping} into g
             select new
             {
                 ItemID = g.Key.ItemID,
                 Estimate = g.Key.EstimatedShipping,
                 ActualShipCosts = g.Select(gSales => gSales.ActualShipping).ToList()
             }).ToList();
