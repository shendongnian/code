    void grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
       DataGridViewCell cell = grid.Rows[e.RowIndex].Cells[e.ColumnIndex];
       if (cell.Value is double && 0 == (double)cell.Value) { e.CellStyle.ForeColor = Color.Red; }
    }
