    DataContext context = new DataContext();
    Order ord = context.Orders.FirstOrDefault();
    ord.OrderItem.Add(new OrderItem() {
        ItemId = 8, Quantity = 2, DateCreated = DateTime.Now });
    // At this point, both Order and Item navigation property of the OrderItem
    // are null
    // Explanation: That's clear because you don't set Order and Item property
    context.SaveChanges();
    // After saving the changes, the Order navigation property of the OrderItem
    // is no longer null, but points to the order. However, the Item navigation
    // property is still null.
    // Explanation: SaveChanges internally fixes relationships with objects that are
    // attached to the context. Order is attached, Item is not. That's why only
    // the Order property is set
    ord = context.Orders.FirstOrDefault();
    // After retrieving the order from the context once again, Item is still null.
    // Explanation: Because the Order is already attached a new query won't replace
    // it. The entity remains the same as before.
    context.Dispose();
    context = new DataContext();
    ord = context.Orders.FirstOrDefault();
    // After disposing of the context and creating a new one, then reloading the
    // order, both Order and Item navigation props are not null anymore
    // Explanation: In a new context the Order will be loaded as a proxy. So, now
    // lazy loading will work and load the Item property
