    private static void ProcessFile(string FilePath, string TableName)
	{
		var dt = GetDataTable(FilePath, TableName);
		if (dt == null)
		{
			return;
		}
		if (dt.Rows.Count == 0)
		{
			AuditLog.AddInfo("No rows imported after reading file " + FilePath);
			return;
		}
		ClearData(TableName);
		InsertData(dt);
	}
	private static DataTable GetDataTable(string FilePath, string TableName)
	{
		var dt = new DataTable(TableName);
		using (var csvReader = new TextFieldParser(FilePath))
		{
			csvReader.SetDelimiters(new string[] { "," });
			csvReader.HasFieldsEnclosedInQuotes = true;
			var readFields = csvReader.ReadFields();
			if (readFields == null)
			{
				AuditLog.AddInfo("Could not read header fields for file " + FilePath);
				return null;
			}
			foreach (var dataColumn in readFields.Select(column => new DataColumn(column, typeof(string)) { AllowDBNull = true, DefaultValue = string.Empty }))
			{
				dt.Columns.Add(dataColumn);
			}
			while (!csvReader.EndOfData)
			{
				var data = csvReader.ReadFields();
				if (data == null)
				{
					AuditLog.AddInfo(string.Format("Could not read fields on line {0} for file {1}", csvReader.LineNumber, FilePath));
					continue;
				}
				var dr = dt.NewRow();
				for (var i = 0; i < data.Length; i++)
				{
					if (!string.IsNullOrEmpty(data[i]))
					{
						dr[i] = data[i];
					}
				}
				dt.Rows.Add(dr);
			}
		}
		return dt;
	}
	private static void ClearData(string TableName)
	{
		SqlHelper.ExecuteNonQuery(ConfigurationUtil.ConnectionString, CommandType.Text, "TRUNCATE TABLE " + TableName);
	}
	private static void InsertData(DataTable table)
	{
		using (var sqlBulkCopy = new SqlBulkCopy(ConfigurationUtil.ConnectionString))
		{
			sqlBulkCopy.DestinationTableName = table.TableName;
			for (var count = 0; count < table.Columns.Count; count++)
			{
				sqlBulkCopy.ColumnMappings.Add(count, count);
			}
			sqlBulkCopy.WriteToServer(table);
		}
	}
