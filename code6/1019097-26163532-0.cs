    public static IEnumerable<ViewModel.Customer> GetCustomers()
    {
	    var dbContext = new EntitiesModel();
    
	    return dbContext.Customers.Select(customer => new ViewModel.Customer
	    {
		    CustomerID = customer.CustomerID,
		    FirstName = customer.FirstName,
	    }).ToList();
    }
