    class RoundedButton : Button
    {
       GraphicsPath GetRoundPath(Rectangle Rect, int radius)
       {
          GraphicsPath GraphPath = new GraphicsPath();
          GraphPath.AddArc(Rect.X, Rect.Y, radius, radius, 180, 90);
          GraphPath.AddArc(Rect.X + Rect.Width - radius, Rect.Y, radius, radius, 270, 90);
          GraphPath.AddArc(Rect.X + Rect.Width - radius, 
                           Rect.Y + Rect.Height - radius, radius, radius, 0, 90);
          GraphPath.AddArc(Rect.X, Rect.Y + Rect.Height - radius, radius, radius, 90, 90);
          return GraphPath;
       }
       protected override void OnPaint(PaintEventArgs e)
       {
          base.OnPaint(e);
          Rectangle Rect = new Rectangle(0, 0, this.Width, this.Height);
          Rectangle Rect2 = new Rectangle(1, 1, this.Width-2, this.Height-2);
          GraphicsPath GraphPath = GetRoundPath(Rect, 50);
          GraphicsPath GraphPath2 = GetRoundPath(Rect2, 50);
          this.Region = new Region(GraphPath);
          e.Graphics.DrawPath(Pens.CadetBlue, GraphPath2);
    }
