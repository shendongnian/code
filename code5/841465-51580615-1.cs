    string connectionstring = @"#YOUR DB ConnectionString#";
    using (SqlBulkCopy bcp = new SqlBulkCopy(connectionstring))
    {
        using (var p = new ChoCSVReader("#YOUR CSV FILE#").WithFirstLineHeader())
        {
            bcp.DestinationTableName = "#TABLENAME#";
            bcp.EnableStreaming = true;
            bcp.BatchSize = 10000;
            bcp.BulkCopyTimeout = 0;
            bcp.NotifyAfter = 100;
            bcp.SqlRowsCopied += delegate (object sender, SqlRowsCopiedEventArgs e)
            {
                Console.WriteLine(e.RowsCopied.ToString("#,##0") + " rows copied.");
            };
            bcp.WriteToServer(p.AsDataReader());
        }
    }
