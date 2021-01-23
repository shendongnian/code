    publicvoid FindInterestingOrderItems(bool onlyIncludePendingItemsOverLimit)
    {
        var customers = GetCustomersWithOrders();
        var interestingOrderItems = customers
            .SelectMany(customer => customer.PendingOrders
                .SelectMany(order => order.Items
                    .Where(GetFilter(customer, onlyIncludePendingItemsOverLimit))
                .Union(customer.FailedOrderItems)))
            .OrderByDescending(orderItem => orderItem.Amount);
    }
    private Func<OrderItem, bool> GetFilter(Customer customer, bool onlyIncludePendingItemsOverLimit)
    {
        if (onlyIncludePendingItemsOverLimit)
        {
            return orderItem => orderItem.Amount > customer.MaxOrderItemAmount;
        }
        else
        {
            return orderItem => true;
        }
    }
