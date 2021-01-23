    public void FillTable(List<List<LabelValueTypeGroup>> rows)
    {
        var columnSet = rows.SelectMany(row => row.Select(col => col.Label)).Distinct();
        foreach (var columnLabel in columnSet)
        {
            columnSet.Add(columnLabel);
            var gridColumn = new DataGridTextColumn 
            { 
                Binding = new Binding(string.Format("[{0}]", columnLabel)),
                Header = columnLabel,
            };
            grid.Columns.Add(gridColumn);
        }
        foreach (var row in rows)
        {
            var item = new Dictionary<string, object>();
            foreach (var col in row)
            {
                item[col.Label] = col.Value;
            }
            Items.Add(item);
        }
    }
