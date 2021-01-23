    if(IsDatabaseInExistence(server.TemplateName) == true)
         CreateSQLDatabase(customer.WebAddress);
    
    if(IsDatabaseInExistence(customer.WebAddress) == true)
         RestoreSQLDatabase(server.TemplateName, customer.WebAddress);
