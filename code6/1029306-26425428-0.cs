    public static int GetColumnIndex(this GridView grid, string columnName)
    {
        return grid.Columns.Cast<DataControlField>()
            .Select((c, index) => new { Column = c, Index = index })
            .Where(x => x.Column.HeaderText.Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
            .Select(x => x.Index)
            .DefaultIfEmpty(-1)
            .First();
    }
