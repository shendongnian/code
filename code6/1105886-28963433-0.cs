            using (SolidBrush brush = new SolidBrush(Color.FromArgb(192, 99, 104, 113)))
            {
                using (GraphicsPath path = new GraphicsPath())
                {
                    var rect1 = new Rectangle(e.ClipRectangle.X + (e.ClipRectangle.Width - 40) / 2, e.ClipRectangle.Y, 40, e.ClipRectangle.Height - 1);
                    var rect2 = new Rectangle(e.ClipRectangle.X, e.ClipRectangle.Y + (e.ClipRectangle.Height - 40) / 2, e.ClipRectangle.Width - 1, 40);
                    path.AddRectangle(rect1);
                    path.AddRectangle(rect2);
                    e.Graphics.DrawPath(Pens.DimGray, path);
                    var bgRect1 = new Rectangle(rect1.X + 1, rect1.Y + 1, rect1.Width - 1, rect1.Height - 1);
                    var bgRect2 = new Rectangle(rect2.X + 1, rect2.Y + 1, rect2.Width - 1, rect2.Height - 1);
                    using (GraphicsPath backgroundPath = new GraphicsPath())
                    {
                        backgroundPath.AddRectangle(bgRect1);
                        backgroundPath.AddRectangle(bgRect2);
                        e.Graphics.FillPath(Brushes.White, backgroundPath);
                    }
                }
            }
