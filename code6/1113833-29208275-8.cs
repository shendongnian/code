    string sqlConnectionString = "server, db, user, pass, etc.";
	using (var connection = new SqlConnection(sqlConnectionString))
	using (var command = new SqlCommand("dbo.UpsertYourTable", connection))
    {
        command.CommandType = CommandType.StoredProcedure;
        var tvp = new SqlParameter("@Table", SqlDbType.Structured);
        tvp.Value = dataTable;
        tvp.TypeName = "dbo.YourTableType";
        command.Parameters.Add(tvp);
        command.ExecuteNonQuery();
    }
