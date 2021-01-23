    bool[] keepColumn = new bool[table.Columns.Count];
    for (int i = 0; i < table.Rows.Count; i++)
    {
        for (int j = 0; j < table.Columns.Count; j++)
        {
            if (!keepColumn[j] &&
                !string.IsNullOrWhiteSpace(table.Columns[j].ToStringOrNull()))
            {
                keepColumn[j] = true;
            }
        }
    }
    for (int i = table.Columns.Count - 1; i >= 0; i--)
    {
        if (!keepColumn[i])
        {
            table.Columns.RemoveAt(i);
        }
    }
