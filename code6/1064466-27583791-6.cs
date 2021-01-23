    // Check if a row is selected.
    if (admin.gridClients.SelectedRows.Length > 0)
    {
        // Rows are selected, use the first.
        var value = admin.gridClients.SelectedRows[0].Cells[0].Value.ToString();
        MessageBox.Show(value);
        // Now use "value" in code.
        // ...
    }
