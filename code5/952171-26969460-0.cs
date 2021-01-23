    var customers = IntuitServiceConfig.ServiceManager.FindAll<Customer>(new Customer(), 1, 100); 
    foreach (Intuit.Ipp.Data.Customer customer in customers)
    {
        Customer resultCustomer = IntuitServiceConfig.ServiceManager.FindById(customer) as Customer;
    
        //Mandatory Fields
        resultCustomer.GivenName = "Bob";
        resultCustomer.Title = "Mr.";
        resultCustomer.MiddleName = "Anto";
        resultCustomer.FamilyName = "Bob";
    
        Customer result = IntuitServiceConfig.ServiceManager.Update(resultCustomer) as Customer;
    }
