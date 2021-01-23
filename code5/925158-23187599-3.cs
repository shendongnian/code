    public static Bitmap TakeDialogScreenshot(Form window)
    {
       var b = new Bitmap(window.Width, window.Height);
       window.DrawToBitmap(b, new Rectangle(0, 0, window.Width, window.Height));
       Point p = window.PointToScreen(Point.Empty);
       Bitmap target = new Bitmap( window.ClientSize.Width, window.ClientSize.Height);
       using (Graphics g = Graphics.FromImage(target))
       {
         g.DrawImage(b, 0, 0,
                     new Rectangle(p.X - window.Location.X, p.Y - window.Location.Y, 
                                   target.Width, target.Height),  
                    GraphicsUnit.Pixel);
       }
       b.Dispose();
       return target;
    }
