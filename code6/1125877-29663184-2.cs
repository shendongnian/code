    public List<MyTable> InsertEntries(double[] entries)
    {
        const string query =
            "INSERT INTO \"MyTable\" (\"Value\") VALUES (:val) RETURNING \"ID\"";
        // Get the result set without auto-assigned ids
        var result = entries.Select(e => new MyTable { Value = e }).ToList();
        // Add each entry to the database asynchronously
        var taskList = new List<Task<IEnumerable<int>>>();
        foreach (var entry in result)
        {
            var queryParams = new DynamicParameters();
            queryParams.Add("val", entry.Value);
            taskList.Add(connection.QueryAsync<int>(
                query, queryParams, transaction));
        }
        // Now that all queries have been sent, start reading the results
        for (var i = 0; i < result.Count; ++i)
        {
            result[i].ID = taskList[i].Result.First();
        }
        // Return the result
        return result;
    }
