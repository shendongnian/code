    using (var bulkCopy = new SqlBulkCopy(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, SqlBulkCopyOptions.KeepNulls & SqlBulkCopyOptions.KeepIdentity))
                    {
                        bulkCopy.BatchSize = (int)DetailLines;
                        bulkCopy.DestinationTableName = "dbo.myTable";
                        bulkCopy.ColumnMappings.Clear();
                        bulkCopy.ColumnMappings.Add("SourceColumnName", "DestinationColumnName");
                        bulkCopy.ColumnMappings.Add("SourceColumnName", "DestinationColumnName");
                       
    
                        bulkCopy.WriteToServer(datatable);
                    }
