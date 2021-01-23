    private async Task<Customer> CreateOrGetCustomer(IEntities db, int customerId)
    {
        var customer = await db.Customers.FirstOrDefaultAsync(x => x.CustomerId == customerId);
        if (customer == null)
        {
            customer = new Customer { CustomerId = customerId };
            db.Customers.Add(customer);
            await db.SaveChangesAsync();
        }
        return customer;
    }
