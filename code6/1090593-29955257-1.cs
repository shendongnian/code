    Bitmap NewImage = new Bitmap(OriginalImage.Width, OriginalImage.Height, OriginalImage.PixelFormat);
    using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(NewImage)) {
    	g.DrawImage(OriginalImage, new Rectangle(0, 0, NewWidth, NewHeight), 0, 0, OriginalImage.Width, OriginalImage.Height, GraphicsUnit.Pixel);
    }
    NewImage.Save("myTransparent.png");
