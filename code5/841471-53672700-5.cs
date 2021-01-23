    public void BulkCopy(string tableName, IDataReader dataReader, Action<SqlBulkCopy>  configureSqlBulkCopy)
    {
        using (SqlConnection dbConnection = new SqlConnection(connectionString))
        {
            dbConnection.Open();
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(dbConnection))
            {
                bulkCopy.BatchSize = 3000; //Data will be sent to SQL Server in batches of this size
                bulkCopy.EnableStreaming = true;
                bulkCopy.DestinationTableName = tableName;
                //This will ensure mapping based on names rather than column position
                foreach (DataColumn column in dataReader.GetSchemaTable().Columns)
                {
                    bulkCopy.ColumnMappings.Add(column.ColumnName, column.ColumnName);
                }
                //If additional, custom configuration is required, invoke the action
                configureSqlBulkCopy?.Invoke(bulkCopy);
                try
                {
                    // Write from the source to the destination.
                    bulkCopy.WriteToServer(dataReader);
                }
                finally
                {
                    dataReader.Close();
                }
            }
        }
    }
