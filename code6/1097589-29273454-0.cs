    using (var conn = new MySqlConnection(connectionString))
    {
        var bl = new MySqlBulkLoader(conn);
        bl.TableName = tableName;
        bl.Timeout = 600;
        bl.FieldTerminator = ",";
        bl.LineTerminator = "\r\n";
        bl.FileName = tempFilePath;
        bl.NumberOfLinesToSkip = 1;
        numberOfInsertedRows = bl.Load();
    }
