    for (var i = 0; i < table.Columns.Count; i++)
    {
        if (Enumerable.Range(0, table.Rows.Count).All(
            j => string.IsNullOrWhiteSpace(tables.Rows[j][i].ToStringOrNull())))
        {
            table.Columns.RemoveAt(i--);
        }
    }
