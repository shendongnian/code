    public List<MyTable> InsertEntries(double[] entries)
    {
        // Create a variable used to dynamically build the query
        var query = new StringBuilder(
            "INSERT INTO \"MyTable\" (\"Value\") VALUES ");
        // Create the dictionary used to store the query parameters
        var queryParams = new DynamicParameters();
        // Get the result set without auto-assigned ids
        var result = entries.Select(e => new MyTable { Value = e }).ToList();
        // Add a unique parameter for each id
        var paramIdx = 0;
        foreach (var entry in result)
        {
            var paramName = string.Format("value{1:D6}", paramIdx);
            if (0 < paramIdx++) query.Append(',');
            query.AppendFormat("(:{0})", paramName);
            queryParams.Add(paramName, entry.Value);
        }
        query.Append(" RETURNING \"ID\"");
        // Execute the query, and store the ids
        var ids = connection.Query<int>(query, queryParams, transaction);
        ids.ForEach((id, i) => result[i].ID = id);
        // Return the result
        return result;
    }
