    private static IEnumerable<SqlDataRecord> TransformStringList(ICollection<string> source)
    {
         if (source == null || source.Count == 0)
         {
             return null;
         }
         return GetRecords(source, 
                           () => new SqlDataRecord(new SqlMetaData("Value", SqlDbType.NVarChar, -1)), 
                           (record, value) => record.SetString(0, value));
    }
    private static IEnumerable<SqlDataRecord> GetRecords<T>(IEnumerable<T> source, Func<SqlDataRecord> factory, Action<SqlDataRecord, T> hydrator)
    {
        SqlDataRecord dataRecord = factory();
        foreach (var value in source)
        {
            hydrator(dataRecord, value);
            yield return dataRecord;
        }
    }
    private InsertStrings(ICollection<string> strings, SqlConnection connection)
    {
        using (var transaction = connection.BeginTransaction())
        {
            using (var cmd = new SqlCommand("dbo.InsertStrings"))
            {
                cmd.Connection = connection;
                cmd.Transaction = transaction;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Paths", SqlDbType.Structured) { Value = TransformStringList(strings) };
                cmd.ExecuteNonQuery();
            }
        }
    }
