    private Point mouseDown;
    
    private void picZoom_MouseDown(object sender, MouseEventArgs e)
    {
        mouseDown = e.Location;
    }
    private void picZoom_MouseMove(object sender, MouseEventArgs e)
    {
        Point pnt;
        int x, y;
        if (MouseButtons.Left == e.Button)
        {
            pnt = picZoom.PointToScreen(e.Location);
            pnt = this.PointToClient(pnt);
            x = pnt.X - mouseDown.X;
            y = pnt.Y - mouseDown.Y;
            if (x < picImage.Left)
            {
                x = picImage.Left;
            }
            else if (x + picZoom.Width > picImage.Left + picImage.Width)
            {
                x = picImage.Left + picImage.Width - picZoom.Width;
            }
            else
            { }
            if (y < picImage.Top)
            {
                y = picImage.Top;
            }
            else if (y + picZoom.Height > picImage.Top + picImage.Height)
            {
                y = picImage.Top + picImage.Height - picZoom.Height;
            }
            else
            { }
            picZoom.Location = new Point(x, y);
        }
    }
