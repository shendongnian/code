    Rectangle outerRect = ClientRectangle;
    Rectangle rect = Rectangle.Inflate(outerRect, -20, -20);
    using (Image img = new Bitmap("test.jpg"))
    {
        g.DrawImage(img, outerRect);
        using (SolidBrush brush = new SolidBrush(Color.White))
        using (GraphicsPath path = new GraphicsPath())
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            path.AddEllipse(rect);
            path.AddRectangle(outerRect);
                    
            g.FillPath(brush, path);
        }
    }
