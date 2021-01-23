    using (SqlConnection destinationConnection = new SqlConnection(connectionString))
    {
        destinationConnection.Open();
        using (SqlTransaction transaction = destinationConnection.BeginTransaction())
        {
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(
                       destinationConnection, SqlBulkCopyOptions.KeepIdentity,
                       transaction))
            {
                bulkCopy.BatchSize = 10;
                bulkCopy.DestinationTableName = "dbo.BulkCopyDemoMatchingColumns";
                // Write from the source to the destination. 
                // This should fail with a duplicate key error. 
                try
                {
                    bulkCopy.WriteToServer(reader);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    transaction.Rollback();
                }
                finally
                {
                    reader.Close();
                }
            }
        }
    }
