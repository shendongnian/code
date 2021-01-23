	using (var connection = new SqlConnection("Connection String"))
	using (var command = new SqlCommand("SELECT * FROM tblBooks WHERE BookID IN (SELECT ID FROM @IDs)", connection))
	{
        var param = new SqlParameter("@Ids", SqlDbType.Structured);
        param.TypeName = "dbo.ListofInt";
        param.Value = table;
        command.Parameters.Add(table);
        connection.Open();
		// ETC
	}
