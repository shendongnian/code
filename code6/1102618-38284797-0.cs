    // CONFIGURE & MAP entity
    DapperPlusManager.Entity<Order>()
                     .Table("Orders")
                     .Identity(x => x.ID);
    
    // CHAIN & SAVE entity
    connection.BulkInsert(orders)
              .AlsoInsert(order => order.Items);
              .Include(x => x.ThenMerge(order => order.Invoice)
                             .AsloMerge(invoice => invoice.Items))
              .AlsoMerge(x => x.ShippingAddress);   
