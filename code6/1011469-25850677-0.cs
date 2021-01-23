    // a named collection of lists of doubles:
    Dictionary<string, List<double>> values = new Dictionary<string, List<double>>();
    // set up the values-dictionary from column names:
    foreach (DataGridViewColumn column in dataGridView1.Columns)
    {
        values.Add(column.Name, new List<double>());
    }
    // load all values into the values-dictionary from the dvg:
    foreach (DataGridViewRow row in dataGridView1.Rows)
    {
        foreach (DataGridViewCell cell in row.Cells)
            values[cell.OwningColumn.Name].Add( Convert.ToDouble(cell.Value) );
    }
