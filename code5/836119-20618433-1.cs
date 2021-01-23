    using (OleDbConnection con = new OleDbConnection(connectionString))
    {
        con.Open();
        DataTable dt = con.GetSchema("Tables");
        string firstSheet = dt.Rows[0]["TABLE_NAME"].ToString();
        ...... work with the first sheet .....
    }
