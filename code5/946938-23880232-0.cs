    Bitmap originalBitmap = (Bitmap)eventArgs.Frame.Clone(); //cloning is not necessary
    Bitmap tmpImage1 = new Bitmap(originalBitmap.Width, originalBitmap.Height);
    Graphics g = Graphics.FromImage(tmpImage1);
    int left = originalBitmap.Width / 4;
    int top = originalBitmap.Height / 4;
    int width = originalBitmap.Width / 2;
    int height = originalBitmap.Height / 2;
    Rectangle srcRect = new Rectangle(left, top, width, height);
    Rectangle dstRect = new Rectangle(0, 0, tmpImage1.Width, tmpImage1.Height);
    g.DrawImage(originalBitmap, dstRect, srcRect, GraphicsUnit.Pixel);
