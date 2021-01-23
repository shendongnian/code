    public List<MyTable> InsertEntries(double[] entries)
    {
        const string query =
            "INSERT INTO \"MyTable\" (\"Value\") VALUES (:val) RETURNING \"ID\"";
        // Get the result set without auto-assigned ids
        var result = entries.Select(e => new MyTable { Value = e }).ToList();
        // Add each entry to the database
        foreach (var entry in result)
        {
            var queryParams = new DynamicParameters();
            queryParams.Add("val", entry.Value);
            entry.ID = connection.Query<int>(
                query, queryParams, transaction);
        }
        // Return the result
        return result;
    }
