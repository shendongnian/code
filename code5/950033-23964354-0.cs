    Point topLeft = new Point(Math.Min(point1.X, point2.X), Math.Min(point1.Y, point2.Y));
    Point botRight = new Point(Math.Max(point1.X, point2.X), Math.Max(point1.Y, point2.Y));
    TextRenderer.DrawText(e.Graphics, "X", this.Font,
                   new Rectangle(topLeft,
                     new Size(botRight.X - topLeft.X, botRight.Y - topLeft.Y)),
                   Color.Black, Color.White,
                  TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
