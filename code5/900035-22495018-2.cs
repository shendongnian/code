    // Optional properties for dynamic sorting
    var orders = new[]
    {
        new OrderByPropertyName {Desc = true, PropertyName = "Preventable"},
        new OrderByPropertyName {Desc = false, PropertyName = "ID"},
        new OrderByPropertyName {Desc = true, PropertyName = "Total"},
    };
    var firstOrder = orders.First();
    var sortedSummary = firstOrder.Desc
        ? summary.AsQueryable().OrderByDescending(firstOrder.PropertyName)
        : summary.AsQueryable().OrderBy(firstOrder.PropertyName);
    foreach (var order in orders.Except(new[] {firstOrder}))
    {
        sortedSummary = order.Desc
            ? summary.AsQueryable().OrderByDescending(order.PropertyName)
            : summary.AsQueryable().OrderBy(order.PropertyName);
    }
    var result = sortedSummary.ToList();
