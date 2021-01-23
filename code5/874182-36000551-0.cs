    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
    {
    	foreach (System.Data.DataColumn c in table.Columns)
    	{
    		bulkCopy.ColumnMappings.Add(c.ColumnName, c.ColumnName);
    	}
    	bulkCopy.DestinationTableName = table.TableName;
    	bulkCopy.WriteToServer(table);
    }
