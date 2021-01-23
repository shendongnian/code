    var trackingItems = itemCounts
    	.Select(i => new ItemTracking
    		{
    			availabilityStatusID = availabilityStatusId,
    			itemBatchId = i.ItemBatchId,
    			locationID = locationId,
    			serialNumber = serialNumber,
    			trackingQuantityOnHand = i.CycleQuantity
    		});
    _context.ItemTrackings.AddRange(trackingItems);
    _context.SaveChanges();
    
    var inventoryTransactions = trackingItems
    	.Select(t => new InventoryTransaction
    		{
    			activityHistoryID = newInventoryTransaction.activityHistoryID,
    			itemTrackingID = t.ItemTrackingID,
    			personID = newInventoryTransaction.personID,
    			usageTransactionTypeId = newInventoryTransaction.usageTransactionTypeId,
    			transactionDate = newInventoryTransaction.transactionDate,
    			usageQuantity = usageMultiplier * t.trackingQuantityOnHand
    		});
    _context.InventoryTransactions.AddRange(inventoryTransactions);
    _context.SaveChanges();
