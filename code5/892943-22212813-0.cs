	string abc = null;
	using (OleDbConnection conn = new SqlConnection(connstring))
	{
		conn.Open();
		OleDbCommand get_lastname = new OleDbCommand("SELECT lastname FROM tbltransactionhistory where name LIKE @name", conn);
		get_lastname.Parameters.AddWithValue("@name", txtname.Text);
		abc = (string)get_lastname.ExecuteScalar();
	}
