    Point p = Point.Empty; // stores location of last mouseclick
    bool clicked = false;  // is picturebox clicked (if yes - circle should be drawn)
    private void pictureBox1_MouseClick( object sender, MouseEventArgs e )
    {
        p = e.Location;         // capture mouse click position
        clicked = true;         // notify the circle has to be drawn
        pictureBox1.Refresh();  // force refresh of the control
    }
    private void pictureBox1_Paint( object sender, PaintEventArgs e )
    {
        // if there's a circle to be drawn
        if ( clicked )
        {
            Graphics g = e.Graphics;   // grab graphics object
            g.DrawEllipse( Pens.Yellow, p.X - 4, p.Y - 4, 8, 8 );  // draw ellipse (a small one in this case)
        }
    }
