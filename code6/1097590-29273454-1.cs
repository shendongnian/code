    using (var conn = new MySqlConnection(connectionString))
    {
        var bl = new MySqlBulkLoader(conn)
        {
            TableName = tableName,
            Timeout = 600,
            FieldTerminator = ",",
            LineTerminator = "\r\n",
            FileName = tempFilePath,
            NumberOfLinesToSkip = 1
        };
        var numberOfInsertedRows = bl.Load();
    }
