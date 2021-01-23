    [QueryInterceptor("Customers")] // only show active customers
    public Expression<Func<Customers, bool>> ActiveCustomers()
    {
        return cust => cust.IsDeleted == false;
    }
