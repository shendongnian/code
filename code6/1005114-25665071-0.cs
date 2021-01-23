    var custDetails = from c in nwDB.Customers select new { 
        c.CustomerID, 
        c.CompanyName, 
        c.ContactName, 
        c.City, 
        c.Country, 
        c.PostalCode, 
        c.Phone, 
        c.Fax
    };
    using (var redis = new RedisClient())
    {
        var customers = redis.As<CustomerR>();
        foreach(var customer in custDetails)
        {
            // The key for this customer
            var customerKey = string.Format("Customer:{0}", customer.CustomerID);
            // Store the customer
            // Use ConvertTo<T> to auto map the properties
            customers.SetEntry(customerKey, customer.ConvertTo<CustomerR>());
        }
    }
