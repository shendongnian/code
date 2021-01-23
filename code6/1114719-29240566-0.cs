    private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
    {
        var dg = (DataGridView) sender;
        if (e.ColumnIndex == -1 || e.RowIndex != (dg.RowCount - 1))
            return;
        using (var p = new Pen(Color.Red, 1))
        {
            var cellBounds = e.CellBounds;
            const int size = 2;
            var pts = new List<Point>();
            var h = false;
            for (int i = cellBounds.Left; i <= cellBounds.Right; i += size,h = !h)
            {
                pts.Add(
                    new Point
                    {
                        X = i,
                        Y = h ? cellBounds.Bottom : cellBounds.Bottom + size
                    });
            }
            e.Graphics.DrawLines(p, pts.ToArray());
        }
    }
