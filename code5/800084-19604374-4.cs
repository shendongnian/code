    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(MDFConnection))
    {
        bulkCopy.DestinationTableName = "CUSTOMER";
        bulkCopy.WriteToServer(tempcereader);
    }
