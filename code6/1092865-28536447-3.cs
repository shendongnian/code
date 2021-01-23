    BasicTable basicTable;
    string strSQL = "Select * From Cars";
    using (DataTable table = new DataTable())
    {
        using (SqlDataAdapter adapter = new SqlDataAdapter(strSQL, connection))
        {
            adapter.Fill(table);
        }
        basicTable = BasicTable.Parse(table);
    }
