    using (OdbcConnection con = new OdbcConnection(myConnectionString))
    {
        con.Open();
        String path = con.Database;
        Console.WriteLine(path);
