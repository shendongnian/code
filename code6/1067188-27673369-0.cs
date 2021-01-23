    public DataTable getDataSet(string query)
    {
        MySqlConnection conn = new MySqlConnection(conn_string);
        if (startConnection(conn) == true)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            DataTable table = new DataTable();
            adapter.Fill(table);
            closeConnection(conn);
            return table;
        }
        return null;
    }
