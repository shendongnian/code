            private void SaveNewData()
            {
                if (cmdThesis.Connection.State == ConnectionState.Open)
                {
                    cmdThesis.Connection.Close();
                }
    
                SqlBulkCopy bulkCopy = new SqlBulkCopy(@"Data Source=.;Initial Catalog=YourDb;Integrated Security=True");
                bulkCopy.BatchSize = 3000;
                bulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping("Col1", "Col1"));
                bulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping("Col2", "Col2"));
                bulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping("Col3", "Col3"));
                bulkCopy.ColumnMappings.Add(new SqlBulkCopyColumnMapping("Col4", "Col4"));
                bulkCopy.DestinationTableName = "DestinationTable";
                bulkCopy.WriteToServer(Result);
    
                Result.Rows.Clear();
    
            }
