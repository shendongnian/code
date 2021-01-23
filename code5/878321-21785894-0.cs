    private void DrawMarker(Graphics gfx, Rectangle r, int radius, Pen drawPen, Position direction) {
      using (GraphicsPath gfxPath = new GraphicsPath()) {
        gfxPath.AddArc(new Rectangle(r.X + r.Width - radius, r.Y + 0, radius, radius), 270, 45); //tr
        if (direction == Position.Right) {
          gfxPath.AddArc(new Rectangle(r.X + r.Width - radius + 20, r.Y + r.Height / 2 - radius / 2, radius, radius), 315, 90); //right
        }
        gfxPath.AddArc(new Rectangle(r.X + r.Width - radius, r.Y + r.Height - radius, radius, radius), 45, 45); //br
        gfxPath.AddArc(new Rectangle(r.X + 0, r.Y + r.Height - radius, radius, radius), 90, 90); //bl
        gfxPath.AddArc(new Rectangle(r.X + 0, r.Y + 0, radius, radius), 180, 90); //tl
        gfxPath.CloseAllFigures();
        gfx.DrawPath(drawPen, gfxPath);
      }
    }
    protected override void OnPaint(PaintEventArgs e) {
      e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
      using (Pen pen = new Pen(Color.DarkGray, 2)) {
        DrawMarker(e.Graphics, new Rectangle(16, 16, 100, 32), 8, pen, Position.Right);
      }
      base.OnPaint(e);
    }
