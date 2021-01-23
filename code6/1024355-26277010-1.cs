	string sql = @"INSERT dbo.[Group] (GroupName, Department, CustomerID)
					SELECT	@GroupName, @Department, c.CompanyID
					FROM	dbo.Company1 AS c
					WHERE	c.CompanyName = @CompanyName;";
	string strcon = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
	
	using (var connection = new SqlConnection(strcon))
	using (var command = new SqlCommand(sql, connection))
	{
		connection.Open();
		command.Parameters.Add(@GroupName, SqlDbType.NVarChar, 50).Value = group;
		command.Parameters.Add(@Department, SqlDbType.NVarChar, 50).Value = dept;
		command.Parameters.Add(@CompanyName, SqlDbType.NVarChar, 50).Value = company;
		command.ExecuteNonQuery();
	}
