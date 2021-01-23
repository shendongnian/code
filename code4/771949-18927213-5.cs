    string csDestination = "put here connection string to database";
    
    using (SqlConnection destinationConnection = new SqlConnection(csDestination))
    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destinationConnection))
    {
        bulkCopy.DestinationTableName = "TUrls";
        bulkCopy.WriteToServer(dataTableOfUrls);
    }
