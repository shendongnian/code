    private static List<DataRow> GetDuplicateRows(DataTable table, params string[] keys)
    {
        var duplicates =
            table
            .AsEnumerable()
            .GroupBy(dr => String.Join("-", keys.Select(k => dr[k])), (groupKey, groupRows) => new { Key = groupKey, Rows = groupRows })
            .Where(g => g.Rows.Count() > 1)
            .SelectMany(g => g.Rows)
            .ToList();
    
        return duplicates;
    }
