    public List<MyTable> InsertEntries(double[] entries)
    {
        const string query =
            "SELECT * FROM \"InsertIntoMyTable\"(:entries::\"MyTableType\")";
        // Get the result set without auto-assigned ids
        var result = entries.Select(e => new MyTable { Value = e }).ToList();
        // Convert each entry into a Postgres string
        var entryStrings = result.Select(
            e => string.Format("({0:E16})", e.Value).ToArray();
        // Create a parameter for the array of MyTable entries
        var queryParam = new NpgsqlParameter("entries",
            NpgsqlDbType.Array | NpgsqlDbType.Text)
        {
            Value = entryStrings
        }
        // Perform the insert
        var command = new NpgsqlCommand(query, connection, transaction);
        command.Parameters.Add(queryParam);
        var reader = command.ExecuteReader();
        // Assign each id to the result
        for (var i = 0; reader.Read(); ++i)
        {
            result[i].ID = (int)reader[0];
        }
        // Return the result
        return result;
    }
