    var addItemTracking = new ItemTracking
    {
        ...
    }
    _context.ItemTrackings.Add(addItemTracking);
    var addInventoryTransaction = new InventoryTransaction
    {
        itemTracking = addItemTracking,
        ...
    };
    _context.InventoryTransactions.Add(addInventoryTransaction);
    ...
    _context.SaveChanges();
