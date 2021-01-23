    protected override void OnMouseMove(MouseEventArgs e) {
      base.OnMouseMove(e);
      if (e.Button == MouseButtons.Left) {
        points.Add(new Point(e.X, e.Y));
        this.Invalidate();
      }
    }
    protected override void OnPaint(PaintEventArgs e) {
      base.OnPaint(e);
      e.Graphics.Clear(Color.White);
      e.Graphics.DrawImage(bmp, Point.Empty);
      DrawHighlight(e.Graphics, points.ToArray(), 16, Color.Yellow);
    }
