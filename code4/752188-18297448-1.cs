    dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
    
    // CellPainting event handler for your dataGridView1
    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        if (e.RowIndex == -1 && e.ColumnIndex > -1)
        {
           e.Handled = true;
           using (Brush b = new SolidBrush(dataGridView1.DefaultCellStyle.BackColor))
           {
             e.Graphics.FillRectangle(b, e.CellBounds);
           }
           using (Pen p = new Pen(Brushes.Black))
           {
             p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
             e.Graphics.DrawLine(p, new Point(0, e.CellBounds.Bottom-1), new Point(e.CellBounds.Right, e.CellBounds.Bottom-1));
           }
           e.PaintContent(e.ClipBounds);
        }
    }
