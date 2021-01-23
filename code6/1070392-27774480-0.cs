    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(ConSQL)) {
	if (ConSQL.State == ConnectionState.Closed) {
		ConSQL.Open();
	}
	bulkCopy.ColumnMappings.Add(0, 0);
	bulkCopy.ColumnMappings.Add(1, 1);
	bulkCopy.ColumnMappings.Add(2, 2);
	 
	bulkCopy.DestinationTableName = "dbo.TableName";
	bulkCopy.WriteToServer(dataTable);
	bulkCopy.Close(); //redundant --since using will dispose the object
	 
}
