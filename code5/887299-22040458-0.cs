        public void BatchBulkCopy(string connectionString, DataTable dataTable, string DestinationTbl, int batchSize)
        {
            using (SqlBulkCopy sbc = new SqlBulkCopy(connectionString))
            {
                sbc.DestinationTableName = DestinationTbl;
                string sql = "SELECT name FROM sys.columns WHERE is_identity = 0 AND object_id = OBJECT_ID(@table)";
	            using (var connection = new SqlConnection(connectionString))
	            using (var command = new SqlCommand(sql, connection))
	            {
		            command.Parameters.AddWithValue("@table", DestinationTbl);
		            connection.Open();
		            using (var reader = command.ExecuteReader())
		            {
			            while (reader.Read())
			            {
                            var column = reader.GetString(0);
				            if (dataTable.Columns.Contains(column))
                            {
                                sbc.ColumnMappings.Add(column, column);
                            }
			            }
		            }
	            }
                // Number of records to be processed in one go
                sbc.BatchSize = batchSize;
                // Finally write to server
                sbc.WriteToServer(dataTable);
            }
        }
