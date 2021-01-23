    async Task Foo()
    {
        Customer cust = null;
        using (DataContext context = new DataContext())
        {
          cust = await context.Customers.SingleAsync(c => c.Id == 1);
        }
    }
