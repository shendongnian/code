    List<ServiceOrder> serviceOrders =
        incomingOrders.GroupBy(o => o.OrderNumber)
                      .ToList(g => new ServiceOrder() {
                                           OrderNumber = g.Key,
                                           Orders = g.ToList() });
