    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
            {
                bulkCopy.DestinationTableName = 
                    "dbo.DestinationTableName";
                try
                {
                    bulkCopy.WriteToServer(sourceDataTable);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
