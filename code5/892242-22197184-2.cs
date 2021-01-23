    using (OleDbConnection con = new OleDbConnection())
    {
        con.ConnectionString =
                @"Provider=Microsoft.Jet.OLEDB.4.0;" +
                @"Data Source=C:\Users\Public\test\CsvImportTest\MyDb.mdb;";
        con.Open();
        using (OleDbCommand cmd = new OleDbCommand())
        {
            cmd.Connection = con;
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
        }
        con.Close();
    }
