    foreach (Table table in Tables)
        {
            string columnsTable = GetListOfColumnsOfTable(table);
    
            string bulkCopyStatement = "SELECT {3} FROM [{0}].[{1}].[{2}]";
            bulkCopyStatement = String.Format(bulkCopyStatement, SourceDatabase.Name, table.Schema, table.Name, columnsTable);
    
            using (SqlCommand selectCommand = new SqlCommand(bulkCopyStatement, connection))
            {
                LogFileManager.WriteToLogFile(bulkCopyStatement);
                SqlDataReader dataReader = selectCommand.ExecuteReader();
    
                using (SqlConnection destinationDatabaseConnection = new SqlConnection(destDatabaseConnString))
                {
                    if (destinationDatabaseConnection.State == System.Data.ConnectionState.Closed)
                    {
                        destinationDatabaseConnection.Open();
                    }
    
                    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destinationDatabaseConnection))
                    {
                        bulkCopy.DestinationTableName = String.Format("[{0}].[{1}]", table.Schema, table.Name);
    
                        foreach (Column column in table.Columns)
                        {
                            //it's not needed to perfom a mapping for computed columns!
                            if (!column.Computed)
                            {
                                bulkCopy.ColumnMappings.Add(column.Name, column.Name);
                            }
                        }
    
                        try
                        {
                            bulkCopy.WriteToServer(dataReader);
                            LogFileManager.WriteToLogFile(String.Format("Bulk copy successful for table [{0}].[{1}]", table.Schema, table.Name));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine(ex.StackTrace);
                        }
                        finally
                        {
                            //closing reader
                            dataReader.Close();
                        }
                    }
                }
            }
        }
