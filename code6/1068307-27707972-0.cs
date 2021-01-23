    // Create a table with some rows. 
            DataTable newProducts = MakeTable();
            // Create the SqlBulkCopy object.  
            // Note that the column positions in the source DataTable  
            // match the column positions in the destination table so  
            // there is no need to map columns.  
            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
            {
                bulkCopy.DestinationTableName = 
                    "dbo.BulkCopyDemoMatchingColumns";
                try
                {
                    // Write from the source to the destination.
                    bulkCopy.WriteToServer(newProducts);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
