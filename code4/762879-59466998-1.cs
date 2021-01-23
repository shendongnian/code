    using FluentMigrator.Runner.BatchParser;
    using FluentMigrator.Runner.BatchParser.SpecialTokenSearchers;
    using FluentMigrator.Runner.BatchParser.Sources;
    void Main()
    {
        var connString = "Server=.;Database=mydb;Trusted_Connection=True;";
        var sql = @"select 1;
    GO
    SELECT 2;
    GO 5";
        ExecuteBatchNonQuery(connString, sql);
    }
    
    public static void ExecuteBatchNonQuery(string ConnectionString, string sql)
    {
        var sqlBatch = string.Empty;
        var conn = new SqlConnection(ConnectionString);
        conn.Open();
    
        try
        {
            var parser = new SqlServerBatchParser();
            parser.SqlText += (sender, args) => { sqlBatch = args.SqlText.Trim(); };
            parser.SpecialToken += (sender, args) =>
            {
                if (string.IsNullOrEmpty(sqlBatch))
                    return;
    
                if (args.Opaque is GoSearcher.GoSearcherParameters goParams)
                {
                    using (var command = conn.CreateCommand())
                    {
                        command.CommandText = sqlBatch;
    
                        for (var i = 0; i != goParams.Count; ++i)
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                }
    
                sqlBatch = null;
            };
    
            using (var source = new TextReaderSource(new StringReader(sql), true))
            {
                parser.Process(source, stripComments: true);
            }
    
            if (!string.IsNullOrEmpty(sqlBatch))
            {
                using (var command = conn.CreateCommand())
                {
                    command.CommandText = sqlBatch;
                    command.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            using (var message = new StringWriter())
            {
                message.WriteLine("An error occured executing the following sql:");
                message.WriteLine(string.IsNullOrEmpty(sqlBatch) ? sql : sqlBatch);
                message.WriteLine("The error was {0}", ex.Message);
    
                throw new Exception(message.ToString(), ex);
            }
        }
        finally
        {
            conn?.Dispose();
        }
    }
