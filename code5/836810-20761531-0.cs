    // ...
    
    dt = ConvertToDataTable(list);
    using (SqlConnection cnx = new SqlConnection(myConnectionString))
    {
        using (SqlTranscation tran = cnx.BeginTransaction())
        {
            DeleteData(cnx, tran, list);
    
            using (SqlBulkCopy bulkcopy = new SqlBulkCopy(cnx, SqlBulkCopyOptions.Default, tran))
            {
                bulkcopy.BulkCopyTimeout = 660;
                bulkcopy.DestinationTableName = TabelName;
                bulkcopy.WriteToServer(dt);
            }
            tran.Commit();
        }
    }
