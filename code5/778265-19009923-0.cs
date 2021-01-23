    var customers = 
        from c in ctx.Customers
        orderby c.CustomerRef ascending
        select new { CustomerId = c.CustomerID, CustomerRef = c.CustomerRef }).ToList();
    
    customers.Insert(0, new { CustomerID = -1, CustomerRef = "[Please Select]"});
    
    cboCustomerRef.DataSource = customers;
    cboCustomerRef.ValueMember = "CustomerID";
    cboCustomerRef.DisplayMember = "CustomerRef";
