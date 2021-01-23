    public void DrawSomething(Graphics graphics, Bitmap yourimage)
    {
        Graphics g;
        Bitmap buffer = new Bitmap(yourimage.Width, yourimage.Height, graphics);
        g = Graphics.FromImage(buffer);
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
    
        g.DrawImage(yourimage, 0, 0);
    
        graphics.DrawImage(buffer, 0, 0);
        g.Dispose();
    }
