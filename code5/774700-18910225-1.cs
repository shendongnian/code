    var idQuery = ctx.ItemMovements
        .GroupBy(e => e.ItemID)
        .Select(g => new { ItemID = g.Key, QuantitySum = g.Sum(Quantity) } )
        .Where(e => e.QuantitySum > 10)
        .Select(e => e.ItemID);
    var query = ctx.ItemMovements
        .Include("Item")
        .Where(e => idQuery.Contains(e.ItemID));
