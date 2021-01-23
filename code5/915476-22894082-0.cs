    var ceQuery = c.Select(cust => new CustomerEntity() 
    {
        CustomerID = cust.CustID,
        CustomerName = cust.CustName
    }).Distinct(new CustomerEntityComparer());
