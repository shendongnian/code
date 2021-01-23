    private void scaledPictureBox1_MouseClick(object sender, MouseEventArgs e)
    {
        scaledPictureBox1.ScaledPoints.Add(e.Location);
        scaledPictureBox1.Invalidate();
    }
    private void scaledPictureBox1_Paint(object sender, PaintEventArgs e)
    {
        using (Pen pen = new Pen(Color.Red, 7f))
        {
            foreach (PointF pt in scaledPictureBox1.ScaledPoints)
                scaledPictureBox1.DrawPoint(e.Graphics, pt.X, pt.Y, pen);
        }
    }
