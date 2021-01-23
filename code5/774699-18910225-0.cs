    var idQuery = ctx.ItemMovements
        .GroupBy(e => e.ItemID, (key, g) => new 
            {
                ItemID = key,
                QuantitytySum = g.Sum(ge => ge.Quantity)
            }
        )
        .Where(e => e.QuantitytySum > 10)
        .Select(e => e.ItemID);
    var query = ctx.ItemMovements
        .Include("Item")
        .Where(e => idQuery.Contains(e.ItemID));
