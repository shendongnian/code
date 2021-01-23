    bool priceApplied = cn.OrderDressings.Any(x => x.OrderID == OrderID && x.OrderItemID == ProductID);
    if (priceApplied) {
        var query = (from yy in cn.OrderDressings where yy.OrderID==OrderID && yy.OrderItemID==ProductID select yy.IsPriceApplied);
        // do stuff.
    }
    // else.. do nothing.
