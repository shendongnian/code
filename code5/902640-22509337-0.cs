    public static IEnumerable<IList<object>> StoreProcedureReader(String StoredProcedureName, SqlParameter[] paramters)
    {
        using (var conn = new SqlConnection(MyConnectionString))
        {
            using (var cmd = new SqlCommand(StoredProcedureName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(paramters);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var fieldCount = reader.FieldCount;
                        var results = new object[fieldCount];
                        for(var i = 0; i < fieldCount; ++i)
                        {
                            results[i] = reader[i];
                        }
                        yield return results;
                    }                        
                }
            }
        }
    } 
