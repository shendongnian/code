    connection.Open();
    
    using (var tran = connection.BeginTransaction(IsolationLevel.ReadCommitted))
    {
       using (var bulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.Default, tran))
       {
           bulkCopy.DestinationTableName = "table";
    
           bulkCopy.ColumnMappings.Add("...", "...");                            
    
           using (var dataReader = new ObjectDataReader<MyObject>(data))
           {
              bulkCopy.WriteToServer(dataReader);
           }
    
           tran.Commit();
           return true;
    
       }
    }
