    using (MySqlConnection conn = new MySqlConnection(constr))
	{
		using (MySqlCommand cmd = new MySqlCommand())
		{
			MySqlDataReader rdr = null;
			string[] dados_bd = new string[2];
			conn.Open();
			cmd.Connection = conn;
			cmd.CommandText = sql;
			rdr = cmd.ExecuteReader();
			while (rdr.Read())
				{
					if (estado == 1)
					{
						dados_bd[0] = rdr.GetString(0);
						
