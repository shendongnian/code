	internal DataTable ExecuteQuery(string query)
	{
		DataTable table = new DataTable();
		var refDataAdapter = new MySqlDataAdapter(new MySqlCommand(query, SqlConn));
		refDataAdapter.Fill(table);
		return table;
	}
