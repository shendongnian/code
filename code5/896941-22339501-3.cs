    public void DrawWhatever(Graphics graphics, Bitmap baseImg)
    {
        Graphics g;
        g = Graphics.FromImage(baseImg);
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        
        // Draw a circle.
        MGraphics.FillCircle(baseImg, brush, cx, cy, 5);
    
        Graphics.DrawImageUnscaled(baseImg, 0, 0);
        g.Dispose();
    }
