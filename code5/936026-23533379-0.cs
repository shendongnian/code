	public static DataSet ExecuteStoredProcedure(this SqlConnection connection, string SPName, params object[] parameters)
	{
		using (var cmd = connection.CreateCommand())
		{
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = SPName;
			cmd.CommandTimeout = 60;
			if (connection.State != ConnectionState.Open)
				connection.Open();
			SqlCommandBuilder.DeriveParameters(cmd);
			int index = 1;
			foreach (object p in parameters)
			{
				if (index >= cmd.Parameters.Count)
					break;
				cmd.Parameters[index++].Value = (p == null ? DBNull.Value : p);
			}
			using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
			{
				DataSet res = new DataSet();
				adapter.Fill(res);
				return res;
			}
		}
	}
