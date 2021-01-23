    box[panelBoxNo].Paint += new PaintEventHandler((s, m) =>
    {
       Graphics g = e.Graphics;
       g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
       string text = panelBoxNo.ToString();
       SizeF textSize = g.MeasureString(text, Font);
       PointF locationToDraw = new PointF();
       locationToDraw.X = (pbW / 2) - (textSize.Width / 2);
       locationToDraw.Y = (pbH / 2) - (textSize.Height / 2);
       g.DrawString(text, Font, Brushes.Black, locationToDraw);
       g.DrawRectangle(new Pen(Color.Black), 0, 0, pbW - 1, pbH - 1);
       g.DrawLine(drawLine, 0, 0, 0, pbH);
       g.Dispose();
 
       m.Graphics.DrawImageUnscaled(drawBox, new Point(0, 0)); 
       m.Dispose();
    });
