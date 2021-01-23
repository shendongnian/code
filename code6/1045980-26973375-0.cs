    var stocksCount = items.GroupBy(x => x.ItemID)
                                     .Select(x => new { ItemID = x.Key, ItemCount = x.Count() }).ToList();
    
    var result = from item in items
                                 join stock in stocks
                                 on item.ItemID equals stock.ItemID
                                 select new
                                 {
                                     item.ItemID,
                                     item.ItemName,
                                     item.ProcessId,
                                     item.ReqQTY,
                                     AllocatedStock = (stock.Stock / stocksCount.First(x => x.ItemID == item.ItemID).ItemCount)
                                 };
