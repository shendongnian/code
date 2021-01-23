    Point mouseDownPoint;
    private void innerpanel_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
            this.mouseDownPoint = PointToClient(Cursor.Position);
    }
    private void innerpanel_MouseMove(object sender, MouseEventArgs e)
    {
        Point MouseLoc = PointToClient(Cursor.Position);
        if (e.Button != MouseButtons.Left)
            return;
        if ((mouseDownPoint.X == MouseLoc.X) && (mouseDownPoint.Y == MouseLoc.Y))
            return;
        Point currAutoS = innerpanel.AutoScrollPosition;
        if (mouseDownPoint.Y > MouseLoc.Y)
        {
            //finger slide UP
            if (currAutoS.Y != 0)
                currAutoS.Y = Math.Abs(currAutoS.Y) - 5;
        }
        else if (mouseDownPoint.Y < MouseLoc.Y)
        {
            //finger slide down
            currAutoS.Y = Math.Abs(currAutoS.Y) + 5;
        }
        else
        {
            currAutoS.Y = Math.Abs(currAutoS.Y);
        }
        if (mouseDownPoint.X > MouseLoc.X)
        {
            //finger slide left
            if (currAutoS.X != 0)
                currAutoS.X = Math.Abs(currAutoS.X) - 5;
        }
        else if (mouseDownPoint.X < MouseLoc.X)
        {
            //finger slide right
            currAutoS.X = Math.Abs(currAutoS.X) + 5;
        }
        else
        {
            currAutoS.X = Math.Abs(currAutoS.X);
        }
        innerpanel.AutoScrollPosition = currAutoS;
        mouseDownPoint = MouseLoc; //IMPORTANT
    }
