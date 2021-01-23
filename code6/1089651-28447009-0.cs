    foreach (Customer c in db.Customer.Where(a => a.Active == true))
        client.Index(new MyElasticsearchTypes.Customer()
            {
                CustomerId = c.CustomerId,
                CustomerName = c.CustomerName,
                Description = c.Description
            });
