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
        var queryParam = new {entries = entryStrings};
        // Perform the insert
        var ids = connection.Query<int>(query, queryParam, transaction);
        // Assign each id to the result
        ids.ForEach((id, i) => result[i].ID = id);
        // Return the result
        return result;
    }
