    private void dataGridView1_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
    {
        if (e.Value == null || e.ColumnIndex != 2) // Skip empty cells and columns except #2
            return;
        string input = e.Value.ToString();
        if (!IsValidColorString(input))
            e.Value = String.Empty;  // An updated cells's value is set back to the `e.Value`
    }
