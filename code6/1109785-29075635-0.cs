    // Fill the DataSet.
    DataSet ds = new DataSet();
    ds.Locale = CultureInfo.InvariantCulture;
    FillDataSet(ds);
    
    var contacts = ds.Tables["Contact"].AsEnumerable();
    var orders = ds.Tables["SalesOrderHeader"].AsEnumerable();
    
    var query =
        contacts.SelectMany(
            contact => orders.Where(order =>
                (contact.Field<Int32>("ContactID") == order.Field<Int32>("ContactID"))
                    && order.Field<decimal>("TotalDue") < 500.00M)
                .Select(order => new
                {
                    ContactID = contact.Field<int>("ContactID"),
                    LastName = contact.Field<string>("LastName"),
                    FirstName = contact.Field<string>("FirstName"),
                    OrderID = order.Field<int>("SalesOrderID"),
                    Total = order.Field<decimal>("TotalDue")
                }));
    
    foreach (var smallOrder in query)
    {
        Console.WriteLine("Contact ID: {0} Name: {1}, {2} Order ID: {3} Total Due: ${4} ",
            smallOrder.ContactID, smallOrder.LastName, smallOrder.FirstName,
            smallOrder.OrderID, smallOrder.Total);
    }
