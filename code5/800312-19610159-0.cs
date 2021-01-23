    private void pictureBox_MouseUp(object sender, MouseEventArgs e)
    {
        p = (PictureBox)sender;
        // create a new PictureBox that looks like the original:
        PictureBox PB = new PictureBox();
        PB.Size = p.Size;
        PB.Image = p.Image;
        PB.SizeMode = p.SizeMode;
        PB.BorderStyle = p.BorderStyle;
        // etc...make it look the same
        // ...and place it:
        Control c = GetChildAtPoint(new Point(p.Left - 1, p.Top));
        if (c == null) c = this;
        Point newLoc = c.PointToClient(p.Parent.PointToScreen(p.Location));
        PB.Parent = c;
        PB.Location = newLoc;
        // put the original back where it started:
        p.Location = (Point)p.Tag;
    }
