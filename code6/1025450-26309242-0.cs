    System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder();
    builder["Data Source"] = "(local)";
    builder["integrated Security"] = true;
    //Or Supply User and Password
    builder["Connect Timeout"] = 1000;
    builder["Initial Catalog"] = "AdventureWorks;NewValue=Bad";
    Console.WriteLine(builder.ConnectionString); 
