    using (SqlConnection conn = new SqlConnection(ConnectionString))
    {
        conn.Open();
        using (SqlBulkCopy sqlcpy = new SqlBulkCopy(conn))
        {
            sqlcpy.SqlRowsCopied += new SqlRowsCopiedEventHandler(OnSqlRowsCopied); //<<---- You need to add this here
            sqlcpy.NotifyAfter = 1;
            sqlcpy.BatchSize = batchSize;
            sqlcpy.BulkCopyTimeout = 60;
    
            using (SqlCommand cmd = new SqlCommand(Sql, conn))
            {
                cmd.ExecuteNonQuery();
                sqlcpy.DestinationTableName = TableName;  //copy the datatable to the sql table
                sqlcpy.WriteToServer(dt);
                return sqlcpy.GetRowsCopied();
            }
        }
    }
