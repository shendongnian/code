    public void InsertField(string table, string[] fields, object[] values)
    {
        if (fields.Length != values.Length) {
            throw new ArgumentException(
                "The fields and values arrays must have the same length");
        }
        string fieldNames = String.Join(", ", fields); // ==> "name1, name2, name3"
        // ==> "@p0, @p1, @p2"
        string paramNames = String.Join(", ",
            Enumerable.Range(0, fields.Length - 1)
                .Select(i => "@p" + i)
                .ToArray()
        );
        using (var conn = new SQLiteConnection(_connectionString)) {
            string sql = String.Format("INSERT INTO {0} ({1}) VALUES ({2})",
                                       table, fieldNames, paramNames);
            var command = new SQLiteCommand(sql, conn);
            for (int i = 0; i < values.Length; i++) {
                command.Parameters.AddWithValue("@p" + i, values[i]);
            }
            conn.Open();
            command.ExecuteNonQuery();
        }
    }
