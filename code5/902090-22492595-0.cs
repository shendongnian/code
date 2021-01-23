     [HttpGet]
     public IQueryable<Customer> CustomersAndOrders() {
       var custs = ContextProvider.Context.Customers.Include("Orders");
       return custs;
     }
