    var customers = IntuitServiceConfig.ServiceManager.FindAll<Customer>(new Customer(), 1, 100); 
    foreach (Intuit.Ipp.Data.Customer customer in customers)
    {
        //Mandatory Fields
        customer.GivenName = "Bob";
        customer.Title = "Mr.";
        customer.MiddleName = "Anto";
        customer.FamilyName = "Bob";
    
        Customer result = IntuitServiceConfig.ServiceManager.Update(customer) as Customer;
    }
