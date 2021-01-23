    private void Form1_MouseMove(object sender, MouseEventArgs e)
    {
        Invalidate();
    }
    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        Point pt = PointToClient(Cursor.Position);
        e.Graphics.FillEllipse(Brushes.Yellow, pt.X - 5, pt.Y - 5, 10, 10);
    }
