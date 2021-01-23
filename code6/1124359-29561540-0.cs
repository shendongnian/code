	SqlDataReader reader = cmd.ExecuteReader();
	StringBuilder sb = new StringBuilder();
	
	//Get All column 
	var columnNames = Enumerable.Range(0, reader.FieldCount)
							.Select(reader.GetName)
							.ToList();
	//Create headers
	sb.Append(string.Join(",", columnNames));
    while (reader.Read())
    ....
