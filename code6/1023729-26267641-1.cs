    // Create a new customer orders report.
    CustomerOrdersReport report = new CustomerOrdersReport();
    
    // Get the report data.
    DataTable customersTable = getCustomersData();
    DataTable ordersTable = getOrdersData();
    
    // Set datasources.
    report.Database.Tables["Customers"].SetDataSource(customersTable);
    report.Database.Tables["Orders"].SetDataSource(ordersTable ); // Don't forget this line like I did!!
