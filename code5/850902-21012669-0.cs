    using(var conn = new SqlConnection("ConnectionString"))
    {
    	conn.Open();
    	var cmd = new SqlCommand("SELECT * FROM Table WHERE 1 = 0", conn);
    	var reader = cmd.ExecuteReader();
    	var schema = reader.GetSchemaTable();
    	var size = schema.AsEnumerable()
    	                 .Single(s => s.Field<string>("ColumnName") == "Column")
    					 .Field<int>("ColumnSize");
    	conn.Close();
    }
