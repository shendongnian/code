    using (var db = new customerContext())
    {
    
        // Create a SQL command to execute the stored procedure
        var cmd = db.Database.Connection.CreateCommand();
        cmd.CommandText = "[dbo].[GetAllCustomerAndOrders]";
     
        try
        {
            
            db.Database.Connection.Open();
            // Run the stored procedure
            var reader = cmd.ExecuteReader();
     
            // Read customer from the first result set
            var customers = ((IObjectContextAdapter)db)
                .ObjectContext
                .Translate<Customer>(reader, "Customers", MergeOption.AppendOnly);   
     
     
            foreach (var item in customers) 
            {
                Console.WriteLine(item.Name);
            }        
     
            // Move to second result set and read orders
            reader.NextResult();
            var orders = ((IObjectContextAdapter)db)
                .ObjectContext
                .Translate<Order>(reader, "Orders", MergeOption.AppendOnly);
     
     
            foreach (var item in orders)
            {
                Console.WriteLine(item.OrderNumber);
            }
        }
        finally
        {
            db.Database.Connection.Close();
        }
    }
