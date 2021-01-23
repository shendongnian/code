	var rs = new DataSet();
	string myquery = sql.ToString();
	using (var Astra_db_Conn = new OracleConnection(Astra_conn))
	using (var cmd = new OracleCommand(myquery, Astra_db_Conn))
	using (var adpt = new OracleDataAdapter(cmd))
	{
		Astra_db_Conn.Open();
		adpt.Fill(rs);
	}
