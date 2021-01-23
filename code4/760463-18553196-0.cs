    private void datagridview_CellFormatting(object sender,
                                              dataGridViewCellFormattingEventArgs e) 
    {
        if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex] is DataGridViewImageColumn)
        {
            if (e.Value != null && (bool)e.Value == true)
            {
                e.Value = My.Resources.yourCheckedImage;
            }
            else
            {
                e.Value = null;
            }
        }
    }
