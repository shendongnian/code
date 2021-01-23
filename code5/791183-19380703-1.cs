    // The insert sql statement.
    string sql =
    @"INSERT INTO [dbo].[Archive_Dev02_20131015] (
        [Timestamp],
        [Data],
        [IntField1],
        [...],                         
        [IntField20])
     SELECT * FROM @data;";
    using (SqlCommand cmd = new SqlCommand(sql))
    {
        using (SqlTransaction transaction = connection.BeginTransaction()
        {
            cmd.Connection = connection;
            cmd.Transaction = transaction;
            cmd.Parameters.Add(new SqlParameter("@data", SqlDbType.Structured)
                {
                    Value = TransformSamples(samples);
                });
            int affected = cmd.ExecuteNonQuery();
            transaction.Commit();
        }
    }
    ...
    private static IEnumerable<SqlDataRecord> TransformSamples({YourSampleType} samples)
    {
        var schema = new[]
        {
            new SqlMetaData("Timestamp", SqlDbType.DateTime),
            new SqlMetaData("Timestamp", SqlDbType.VarBinary, -1),
            new SqlMetaData("IntField1", SqlDbType.Int),
            new SqlMetaData("...", SqlDbType.Int),
            new SqlMetaData("IntField20", SqlDbType.Int)
        };
        foreach (var sample in samples)
        {
            var row = new SqlDataRecord(schema);
            row.SetSqlDate(0, sample.ReceiveDate);
            row.SetSqlBinary(1, sample.Data);
            row.SetSqlInt(2, sample.Data.Length);
            row.SetSqlInt(..., ...);
            row.SetSqlInt(24, sample.IntValue19);
            yield return row;
        }
    }
    
