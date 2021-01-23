    public void DrawWhatever(Graphics graphics)
    {
        Graphics g;
        Bitmap buffer = null;
        
        buffer = new Bitmap([image width], [image height], graphics);
        g = Graphics.FromImage(buffer);
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        
        // Draw a circle.
        MGraphics.FillCircle(buffer, brush, cx, cy, 5);
    
        e.Graphics.DrawImageUnscaled(buffer, 0, 0);
        g.Dispose();
    }
