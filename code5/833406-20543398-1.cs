    var datatable = new DataTable();
	datatable.Columns.Add(new DataColumn("Value", typeof(string)));
	for (var i = 0; i < words.Count(); i++)
	{
		var dr = datatable.NewRow();
		dr[0] = words[i];
		datatable.Rows.Add(dr);
	}
	using (var connection = new SqlConnection("your Connection String"))
	using (var command = new SqlCommand("dbo.InsertWords", connection))
	{
		command.CommandType = CommandType.StoredProcedure;
		command.Parameters.Add(new SqlParameter{ 
                                                ParameterName = "@StringList", 
                                                SqlDbType = SqlDbType.Structured,
                                                TypeName = "dbo.StringList",
                                                Value = datatable
                                                });
        connection.Open();
        command.ExecuteNonQuery();
	}
