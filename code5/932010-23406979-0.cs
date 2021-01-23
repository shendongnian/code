    System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder();
    builder["Data Source"] = "(local)";
    builder["integrated Security"] = true;
    builder["Initial Catalog"] = "AdventureWorks;NewValue=Bad";
    Console.WriteLine(builder.ConnectionString);
