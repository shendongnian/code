    private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
    {
        if (dataGridView1.CurrentCell != null && dataGridView1.IsCurrentCellInEditMode && dataGridView1.CurrentCell.ColumnIndex == ColumnSalary.Index)
        {
            ...
        }
    }
