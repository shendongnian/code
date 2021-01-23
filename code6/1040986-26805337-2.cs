    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        Point mp = pictureBox1.PointToClient(Cursor.Position);
        if (e.ClipRectangle.Contains(mp))
        {
            e.Graphics.DrawLine(Pens.Red, 0, mp.Y, e.ClipRectangle.Width, mp.Y);
            e.Graphics.DrawLine(Pens.Red, mp.X, 0, mp.X, e.ClipRectangle.Height);
        }
    }
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        pictureBox1.Invalidate();
    }
