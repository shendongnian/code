       var b = new Bitmap(this.Width, this.Height);
       this.DrawToBitmap(b, new Rectangle(0,0,this.Width, this.Height));
       Point p = this.PointToScreen(Point.Empty);
       Bitmap target = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
       using (Graphics g = Graphics.FromImage(target))
       {
         g.DrawImage(b, 0, 0,
                     new Rectangle(p.X - this.Location.X, p.Y - this.Location.Y, 
                                   target.Width, target.Height),  
                    GraphicsUnit.Pixel);
       }
       b.Dispose();
       return target;
