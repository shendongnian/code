    public void AddCustomer(Customer customer)
    {
        using (var db = new CustomerContext)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
        }
    
        var hub = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
        hub(customer.Id);
    }
