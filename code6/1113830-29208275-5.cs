    string sqlConnectionString = "server, db, user, pass, etc.";
	using (var bulkCopy = new SqlBulkCopy(sqlConnectionString))
	{
        bulkCopy.DestinationTableName = "table";
        bulkCopy.ColumnMappings.Add("Col1", "Col1");
        bulkCopy.ColumnMappings.Add("Col2", "Col2");
        bulkCopy.ColumnMappings.Add("Col3", "Col3");
        bulkCopy.WriteToServer(dataTable);
	}
