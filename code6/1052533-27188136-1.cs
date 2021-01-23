    void panelTitleBar_MouseMove(object sender, MouseEventArgs e)
    {
        if (this.drag)
        { // if we should be dragging it, we need to figure out some movement
            Point p1 = new Point(e.X, e.Y);
            Point p2 = form.PointToScreen(p1);
            Point p3 = new Point(p2.X - form.startPoint.X,
                                 p2.Y - form.startPoint.Y);
            form.Location = p3;
        }
    }
