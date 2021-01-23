    Graphics g = pnlGraph.CreateGraphics();
    Image img = new Bitmap(pnlGraph.Width, pnlGraph.Height);
    Graphics gi = Graphics.FromImage(img);
    gi.DrawRectangle(new Pen(new SolidBrush(pnlGraph.BackColor)), new Rectangle(0, 0, pnlGraph.Width, pnlGraph.Height));
    // For every line:
    gi.DrawLine(new Pen(new SolidBrush(Color.Black), 2), p1, p2);
    // At the end:
    g.DrawImage(img, 0, 0, img.Width, img.Height);
