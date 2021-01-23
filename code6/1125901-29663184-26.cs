    public List<MyTable> InsertEntries(double[] entries)
    {
        // Create a variable used to dynamically build the query
        var query = new StringBuilder(
            "INSERT INTO \"MyTable\" (\"Value\") VALUES");
        // Get the result set without auto-assigned ids
        var result = entries.Select(e => new MyTable { Value = e }).ToList();
        // Add each row directly into the insert statement
        for (var i = 0; i < result.Count; ++i)
        {
            entry = result[i];
            query.Append(i == 0 ? ' ' : ',');
            query.AppendFormat("({0:E16})", entry.Value);
        }
        query.Append(" RETURNING \"ID\"");
        // Execute the query, and store the ids
        var ids = connection.Query<int>(query, null, transaction);
        ids.ForEach((id, i) => result[i].ID = id);
        // Return the result
        return result;
    }
