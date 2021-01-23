    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        var g = e.Graphics;
        g.SmoothingMode = SmoothingMode.HighQuality;
    
        Rectangle textRect = new Rectangle(100, 100, 150, 150);
        Font f = new Font("Arial", 16);
        float emSize = f.Height * f.FontFamily.GetCellAscent(f.Style) /
                   f.FontFamily.GetEmHeight(f.Style);
    
        foreach (StringAlignment lineAlignment in Enum.GetValues(typeof(StringAlignment)))
        {
            foreach (StringAlignment alignment in Enum.GetValues(typeof(StringAlignment)))
            {
                StringFormat sf = new StringFormat() { LineAlignment = lineAlignment, Alignment = alignment };
                using (GraphicsPath gp = new GraphicsPath())
                {
                    gp.AddString("txt", f.FontFamily, (int)f.Style, emSize, textRect, sf);
                    RectangleF bounds = gp.GetBounds();
                    // Calculate the rectangle offset
                    PointF offset = FixAlignment(textRect, bounds, lineAlignment, alignment);
                    // Translate using the offset
                    g.TranslateTransform(offset.X, offset.Y);
                    g.FillPath(Brushes.Black, gp);
                    g.DrawRectangle(Pens.Red, Rectangle.Round(bounds));
                    // Translate back to the original location
                    g.TranslateTransform(-offset.X, -offset.Y);
                }
            }
        }
    
        g.DrawRectangle(Pens.Blue, textRect);
    }
