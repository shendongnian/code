    private void dataGridView1_CellPainting(object sender, 
                                            DataGridViewCellPaintingEventArgs e)
    {
       if (e.CellStyle.BackColor == Color.Yellow)
       {
            int pl = 12;  //  padding left & right
            int pt = 2;   // padding top & bottom
            int cw = e.CellBounds.Width;
            int ch = e.CellBounds.Height;
            int x = e.CellBounds.X;
            int y = e.CellBounds.Y;
            e.PaintBackground(e.ClipBounds, true);
            e.PaintContent(e.CellBounds);
            Brush brush = SystemBrushes.Window;
            e.Graphics.FillRectangle(brush, x, y, pl + 1 , ch - 1);
            e.Graphics.FillRectangle(brush, x + cw - pl - 2, y, pl + 1, ch - 1);
            e.Graphics.FillRectangle(brush, x, y, cw -1 , pt + 1 );
            e.Graphics.FillRectangle(brush, x, y + ch - pt - 2 , cw -1 , pt + 1 );
            e.Handled = true;
        }
    }
