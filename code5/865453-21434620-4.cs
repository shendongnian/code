    var table = new DataTable();
	table.Columns.Add("ID", typeof(int));
	// ADD YOUR LIST TO THE TABLE
	using (var connection = new SqlConnection("Connection String"))
	using (var command = new SqlCommand("dbo.GetBooks", connection))
	{
		command.CommandType = CommandType.StoredProcedure;
        var param = new SqlParameter("@Ids", SqlDbType.Structured);
        param.TypeName = "dbo.ListofInt";
        param.Value = table;
        command.Parameters.Add(table);
        connection.Open();
        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                // do something
            }
        }
	}
