    void panelTitleBar_MouseMove(object sender, MouseEventArgs e)
    {
        Control control = sender as Control;
        if(null != control)
        {
            Form form = control.FindForm();
            if(null != form)
            {
                if (this.drag)
                { // if we should be dragging it, we need to figure out some movement
                    Point p1 = new Point(e.X, e.Y);
                    Point p2 = form.PointToScreen(p1);
                    Point p3 = new Point(p2.X - this.startPoint.X,
                                         p2.Y - this.startPoint.Y);
                    form.Location = p3;
                }
            }
        }
    }
