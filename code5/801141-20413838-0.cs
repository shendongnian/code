    IntPtr m_ip = IntPtr.Zero;
    m_ip = capture.Click();
    Bitmap b = new Bitmap(640, 480, capture.Stride, PixelFormat.Format24bppRgb, m_ip);
    b = ResizeBitmap(b,220,220); //The size of your box
    b.RotateFlip(RotateFlipType.RotateNoneFlipY);
    pictureBox2.Image = b;
    private static Bitmap ResizeBitmap(Bitmap sourceBMP, int width, int height)
    {
       Bitmap result = new Bitmap(width, height);
       using (Graphics g = Graphics.FromImage(result))
       g.DrawImage(sourceBMP, 0, 0, width, height);
       return result;
    }
