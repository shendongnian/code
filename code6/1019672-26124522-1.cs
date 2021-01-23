    private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        // ToDo: insert your own column index magic number 
        if (this.dgv.Rows[e.RowIndex].IsNewRow && e.ColumnIndex == 2)
        {
            e.Value = Properties.Resources.Assign_OneToMany;
        }
    }
