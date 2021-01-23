    using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
    {
        conn.Open();
        bulkCopy.DestinationTableName = "dbo.ObjectInventory";
        bulkCopy.WriteToServer(table);
    }
