    EntityConnection ec = (EntityConnection)Context.Connection;
    SqlConnection sc = (SqlConnection)ec.StoreConnection;
    
    var copy = new SqlBulkCopy(sc, SqlBulkCopyOptions.CheckConstraints | SqlBulkCopyOptions.Default , null);
    
    copy.DestinationTableName = "TableName";
    copy.ColumnMappings.Add("SourceColumn", "DBColumn");
    copy.WriteToServer(dataTable);
    copy.Close();
