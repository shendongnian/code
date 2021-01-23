    public void RegenerateColumns(GridView grid, DataTable data, IDictionary<string, string> columnText)
    {
        grid.Columns.Clear();
        foreach (DataColumn col in data.Columns)
        {
            grid.Columns.Add(new BoundField()
            {
                DataField = col.ColumnName,
                HeaderText = columnText.ContainsKey(col.ColumnName)
                    ? columnText[col.ColumnName]
                    : col.ColumnName
            });
        }
    }
