    public static DataTable ExecuteQuery(string query, string table)
    {
        using(SqlConnection cnn = new SqlConnection(ConnectionInfo))
        using(SqlDataAdapter Adp = new SqlDataAdapter(query, cnn))
        {
            DataTable tbl = new DataTable();
            Adp.Fill(tbl);
            return tbl;
        }
    }
