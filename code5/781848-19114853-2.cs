    using (SqlBulkCopy bulkCopy =
       new SqlBulkCopy(connectionString, SqlBulkCopyOptions.KeepIdentity
                       | SqlBulkCopyOptions.UseInternalTransaction))
    {
       bulkCopy.BatchSize = 10;
       bulkCopy.DestinationTableName = "dbo.BulkCopyDemoMatchingColumns";
    
       try
       {
          bulkCopy.WriteToServer(reader);
       }
       catch (Exception ex)
       {
          Console.WriteLine(ex.Message);
       }
       finally
       {
          bulkCopy.Close();
       }
    }
