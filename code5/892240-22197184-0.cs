    using (OdbcConnection con = new OdbcConnection())
    {
        con.ConnectionString =
                @"Driver={Microsoft Access Driver (*.mdb)};" +
                @"DBQ=C:\Users\Public\test\CsvImportTest\MyDb.mdb;";
        con.Open();
        using (OdbcCommand cmd = new OdbcCommand())
        {
            cmd.Connection = con;
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
        }
        con.Close();
    }
