    Point mouse = Point.Empty;
    private void panel1_MouseMove(object sender, MouseEventArgs e)
    {
        mouse = e.Location;
        panel1.Invalidate();
    }
    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        if (mouse != Point.Empty)
        {
            e.Graphics.DrawLine(Pens.Blue, 0, mouse.Y, panel1.ClientSize.Width, mouse.Y );
            e.Graphics.DrawLine(Pens.Blue, mouse.X, 0,  mouse.X, panel1.ClientSize.Height );
        }
    }
    private void panel1_MouseLeave(object sender, EventArgs e)
    {
        mouse = Point.Empty;
        panel1.Invalidate();
    }
