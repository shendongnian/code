            using (Bitmap newBmp = new Bitmap((int)Width, (int)Height, PixelFormat.Format24bppRgb))
            {
                System.Drawing.Point topLeftPoint = new System.Drawing.Point((int)Top, (int)Left);
                var graphics = Graphics.FromImage(newBmp);
                graphics.CopyFromScreen(topLeftPoint, System.Drawing.Point.Empty, new System.Drawing.Size((int)Width, (int)Height));
                newBmp.Save(@"c:\mypath\blah\", ImageFormat.Png);                
            }
        
