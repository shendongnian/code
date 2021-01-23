    int x, y, w, h;
    private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
    {
      if (e.Row == 1 && e.Column == 0)
      {
        x = e.CellBounds.X;
        y = e.CellBounds.Y;
        w = e.CellBounds.Width;
        h = e.CellBounds.Height;
      }
      if (e.Row == 2 && e.Column == 0)
      {
        h = h + e.CellBounds.Height;
      }
      if (e.Row == 1 && e.Column == 1)
      {
        w = w + e.CellBounds.Width;
      }
      if (e.Row == 3 && e.Column == 3)
      {
        Rectangle rc = new Rectangle(x, y, w, h);
        LinearGradientBrush brush = new LinearGradientBrush(rc, Color.Blue, Color.White, LinearGradientMode.Vertical);
        e.Graphics.FillRectangle(brush, rc);
      }
    }
