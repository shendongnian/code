    List<Tuple<SolidBrush, string>> diffStrings = new List<Tuple<SolidBrush, string>>();
    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.RowIndex != 4 || e.ColumnIndex != 0) { return; }  // only one test-cell
        float x = e.CellBounds.Left + 1;
        float y = e.CellBounds.Top + 1;
        e.PaintBackground(e.CellBounds,true);
        foreach (Tuple<SolidBrush, string> kv in diffStrings)
        {
            SizeF size = e.Graphics.MeasureString(kv.Item2, Font, 
                         e.CellBounds.Size, StringFormat.GenericTypographic);
            if (x + size.Width > e.CellBounds.Left + e.CellBounds.Width)  
               {x = e.CellBounds.Left + 1; y += size.Height; }
            e.Graphics.DrawString(kv.Item2, Font, kv.Item1,   x , y);
            x += size.Width;
        }
        e.Handled = true;
    }
