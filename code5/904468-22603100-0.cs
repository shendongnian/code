    void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.RowIndex != -1 && e.ColumnIndex == columnIndex)
        {
            if ((e.PaintParts & DataGridViewPaintParts.Background) != DataGridViewPaintParts.None)
            {
                e.Graphics.DrawImage(Resources.Image1, e.CellBounds);                    
            }
            if (!e.Handled)
            {
                e.Handled = true;
                e.PaintContent(e.CellBounds);
            }            
        }
    }
