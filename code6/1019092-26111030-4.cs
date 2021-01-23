    public static IEnumerable<Customer> GetCustomers()
    {
        IEnumerable<Customer> result = null;
        using(var dbContext = new EntitiesModel()) 
        {
            result = dbContext.Customers.Select(customer => new ViewModel.Customer
            {
                CustomerID = customer.CustomerID,
                FirstName = customer.FirstName,
                CustomProperty = customer.CustomProperty
            });
        }
        return result.ToList();
    }
