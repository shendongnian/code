    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connectionString))
    {
         bulkCopy.DestinationTableName = "dbo.BulkCopyDemoMatchingColumns";
         try
         {
             // Write from the source to the destination.
             bulkCopy.WriteToServer(reader);
         }
         catch (Exception ex)
         {
             Console.WriteLine(ex.Message);
         }
         finally
         {
             // Close the SqlDataReader. The SqlBulkCopy 
             // object is automatically closed at the end 
             // of the using block.
             reader.Close();
         }
    }
