    if (newOrder.Customer != null && newOrder.Customer.Id != null)
    {
        _db.Orders.Insert(new 
        {
             CreationDate=newOrder.CreationDate,
             CustomerId = newOrder.Customer.Id
        });
    }
