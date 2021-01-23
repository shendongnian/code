    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))     
    {
        bulkCopy.DestinationTableName =  "dbo.BulkCopyDemoMatchingColumns";
        try
        {
            bulkCopy.WriteToServer(newProducts);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
