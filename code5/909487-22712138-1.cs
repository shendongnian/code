    void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.RowIndex == -1 && e.ColumnIndex >= 0 && e.ColumnIndex == myClickedColumnHeaderIndex)
        {
            e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Border);
            using (Pen customPen = new Pen(Color.Blue, 2))
            {
                Rectangle rect = e.CellBounds;
                rect.Width -= 2;
                rect.Height -= 2;
                e.Graphics.DrawRectangle(customPen, rect);
            }
            e.Handled = true;
        }
    }
