    public void DrawWhatever(Graphics graphics, int cx, int cy)
    {
        Graphics g;
        Bitmap buffer = null;
        buffer = new Bitmap([image width], [image height], graphics);
        g = Graphics.FromImage(buffer);
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        
        // Draw a circle.
        Pen p = new Pen(Color.Red,1)
        g.DrawEllipse(p,cx,cy,30,30); //example values
    
        graphics.DrawImage(buffer, 0, 0);
        g.Dispose();
    }
