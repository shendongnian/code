    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (dataGridView1.Columns[e.ColumnIndex].Name == “passwordDataGridViewTextBoxColumn” && e.Value != null)
        {
            dataGridView1.Rows[e.RowIndex].Tag = e.Value;
            e.Value = new String(‘*’, e.Value.ToString().Length);
        }
    }
    private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
    {
        if (dataGridView1.CurrentRow.Tag != null)
            e.Control.Text = dataGridView1.CurrentRow.Tag.ToString();
    }
