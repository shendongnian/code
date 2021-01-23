    public List<PointF> somePoints = new List<PointF>();
    private void scaledPictureBox1_MouseClick(object sender, MouseEventArgs e)
    {
        somePoints.Add(scaledPictureBox1.ScalePoint(e.Location) );
        scaledPictureBox1.Invalidate();
    }
    private void scaledPictureBox1_Paint(object sender, PaintEventArgs e)
    {
        // here we apply the scaling matrix to the graphics object:
        e.Graphics.MultiplyTransform(scaledPictureBox1.ScaleM);
        using (Pen pen = new Pen(Color.Red, 10f))
        {
            PointF center = new PointF(scaledPictureBox1.Width / 2f, 
                                       scaledPictureBox1.Height / 2f);
            center = scaledPictureBox1.ScalePoint(center);
            foreach (PointF pt in somePoints)
            {
                DrawPoint(e.Graphics, pt, pen);
                e.Graphics.DrawLine(Pens.Yellow, center, pt);
            }
        }
    }
    public void DrawPoint(Graphics G, PointF pt, Pen pen)
    {
        using (SolidBrush brush = new SolidBrush(pen.Color))
        {
            float pw = pen.Width;
            float pr = pw / 2f;
            G.FillEllipse(brush, new RectangleF(pt.X - pr, pt.Y - pr, pw, pw));
        }
    }
