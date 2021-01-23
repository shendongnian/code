    // Get valid columns from the [targetTable] on the db at runtime
    // and produce a simple mapping
    // validColumns is an IDictionary<string, string>
    var membersExposedToReader = validColumns.Keys.ToArray();
    
    // data is an IEnumerable<T>           
    using (var bcp = new SqlBulkCopy(sqlConnection, SqlBulkCopyOptions.TableLock, tran))
    using (var reader = ObjectReader.Create(data, membersExposedToReader))
    {
        foreach (var member in membersExposedToReader)
        {
            bcp.ColumnMappings.Add(member, validColumns[member]);
        }
    
        bcp.BulkCopyTimeout = 120;
        bcp.BatchSize = 0;
        bcp.DestinationTableName = targetTable;
        bcp.WriteToServer(reader);
    }
