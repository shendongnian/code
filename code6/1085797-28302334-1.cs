    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.Value != null && e.Value.ToString() != "SSN")
        {
            if (!(dataGridView1.CurrentCell != null && dataGridView1.IsCurrentCellInEditMode && dataGridView1.CurrentCell.RowIndex == e.RowIndex && dataGridView1.CurrentCell.ColumnIndex == e.ColumnIndex))
            {
                e.Value = "****1234";
                e.FormattingApplied = true;
            }
        }
    }
