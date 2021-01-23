    // DataContext takes a connection string. 
    DataContext db = new DataContext(@"c:\Northwnd.mdf");
    // Get a typed table to run queries.
    Table<Customer> Customers = db.GetTable<Customer>();
    // Query for customers from London. 
    var query =
        from cust in Customers
        where cust.City == "London" 
        select cust;
    foreach (var cust in query)
        Console.WriteLine("id = {0}, City = {1}", cust.CustomerID, cust.City);
