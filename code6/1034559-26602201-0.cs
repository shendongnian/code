    private void dataGridView1_NewRowNeeded(object sender,
            DataGridViewRowEventArgs e)
    {
        foreach (DataGridViewCell cell in e.Row.Cells)
        {
            if (cell.Value == "0" || cell.Value == 0) // not sure which you're using
            {
                 cell.Value = "your replacement value here";
            }
        }
    }
