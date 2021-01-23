	static void AutoSqlBulkCopy(DataSet dataSet)
	{
		var sqlConnection = new SqlConnection("Data Source=sqlServer;Initial Catalog=mydatabase;user id=myuser;password=mypass;App=App");
		sqlConnection.Open();
		foreach (DataTable dataTable in dataSet.Tables)
		{
			// checking whether the table selected from the dataset exists in the database or not
			var checkTableIfExistsCommand = new SqlCommand("IF EXISTS (SELECT 1 FROM sysobjects WHERE name =  '" + dataTable.TableName + "') SELECT 1 ELSE SELECT 0", sqlConnection);
			var exists = checkTableIfExistsCommand.ExecuteScalar().ToString().Equals("1");
			// if does not exist
			if (!exists)
			{
				var createTableBuilder = new StringBuilder("CREATE TABLE [" + dataTable.TableName + "]");
				createTableBuilder.AppendLine("(");
				// selecting each column of the datatable to create a table in the database
				foreach (DataColumn dc in dataTable.Columns)
				{
					createTableBuilder.AppendLine("  ["+ dc.ColumnName + "] VARCHAR(MAX),");
				}
				createTableBuilder.Remove(createTableBuilder.Length - 1, 1);
				createTableBuilder.AppendLine(")");
				var createTableCommand = new SqlCommand(createTableBuilder.ToString(), sqlConnection);
				createTableCommand.ExecuteNonQuery();
			}
			// if table exists, just copy the data to the destination table in the database
			// copying the data from datatable to database table
			using (var bulkCopy = new SqlBulkCopy(sqlConnection))
			{
				bulkCopy.DestinationTableName = dataTable.TableName;
				bulkCopy.WriteToServer(dataTable);
			}
		}
	}
