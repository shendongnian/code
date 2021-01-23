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
    // after the List is filled (!) you can access it like an array:
    // load selected values into the values-dictionary from the dvg:
    foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
    {
        values[cell.OwningColumn.Name][cell.RowIndex] = Convert.ToDouble(cell.Value);
    }
    // reload selected values from the corresponding slots in the values-dictionary:
    foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
    {
        cell.Value = values[cell.OwningColumn.Name][cell.RowIndex];
    }
