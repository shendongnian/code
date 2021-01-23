    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connectionString))
    {
      bulkCopy.DestinationTableName = "destination_table";
      bulkCopy.ColumnMappings.Add("variable1", "variable1");
      bulkCopy.ColumnMappings.Add("variable2", "variable2");
      bulkCopy.ColumnMappings.Add("variable3", "variable3");
      // etc.
