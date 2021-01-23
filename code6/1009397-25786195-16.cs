    private void dataGridView1_CellPainting(object sender, 
                                            DataGridViewCellPaintingEventArgs e)
    {
       if (e.RowIndex < 0 | e.ColumnIndex < 0) return;
       if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected)
       {
         e.Graphics.FillRectangle(SystemBrushes.Highlight, e.CellBounds);
         e.Graphics.DrawString(e.Value.ToString(), new Font(e.CellStyle.Font.FontFamily,
         e.CellStyle.Font.Size * 1.5f), SystemBrushes.HighlightText, e.CellBounds.Location);
         e.Handled = true;
       }
    }
