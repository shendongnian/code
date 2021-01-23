    var o = context.Orders;
    if (userHasChosenACustomerId)
    {
        o = o.Where(o => o.CustomerId == theChosenCustomerId);
    }
    if (userHasChosenAProductId)
    {
        o = o.Where(o => o.ProductId == theChosenProductId);
    }    ...
    var result = o.ToList();
