    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
        Invalidate();
    }
    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        float radius = 10f;
        Point pt = PointToClient(Cursor.Position);
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
        e.Graphics.FillEllipse(Brushes.Yellow, pt.X - radius, 
                               pt.Y - radius, radius * 2, radius * 2);
    }
