    using (SqlBulkCopy bulk = new SqlBulkCopy(con, SqlBulkCopyOptions.KeepIdentity))
    {
        bulk.DestinationTableName = "#Prices";
        bulk.WriteToServer(table);
        
    }
