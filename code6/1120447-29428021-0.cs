    using (SqlCeBulkCopy bulkInsert = new SqlCeBulkCopy(connString))
    {
       bulkInsert.DestinationTableName = "testtable";
       bulkInsert.WriteToServer(table);
    }
