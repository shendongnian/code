    DateTime dateFrom = new Date(2014,8,2);
    var GroupedPrices = Prices
        .Where(p => p.ArrivalDateFrom <= dateFrom && p.ArrivalDateTo > dateFrom)
        .GroupBy(p => p.ItemID)
        .Select(g => new{ ItemId = g.Key, NewestPrice = g.OrderByDescending(p => p.ValidFrom).First() });
