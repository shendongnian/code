    Console.WriteLine(
        new XElement("add",
            new XAttribute("name","MyConnectionString"),
            new XAttribute("connectionString",
                new SqlConnectionStringBuilder {
                    DataSource="tcp:xxxxxx.database.windows.net,1433",
                    InitialCatalog="MyDatabase",
                    MultipleActiveResultSets=true,
                    UserID="xxxxxx@xxxxxxxx",
                    Password=Console.ReadLine()
                }
            ),
            new XAttribute("providerName","System.Data.SqlClient")
        )
    );
