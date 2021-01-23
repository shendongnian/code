    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.ColumnIndex == -1 && e.RowIndex == -1)
        {
            e.Graphics.FillRectangle(Brushes.Red, e.ClipBounds);
            e.Handled = true;
        }
    }
