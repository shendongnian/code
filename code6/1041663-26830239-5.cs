    // one example 'object'
    Rectangle R0 = new Rectangle(182,82,31,31);
    // a few helpers
    Point curMouse = Point.Empty;
    Point downMouse = Point.Empty;
    Rectangle RM = Rectangle.Empty;
    float angle = 30;
    Point center = new Point(-55, -22);
    private void canvas_Paint(object sender, PaintEventArgs e)
    {
        // preprare the canvas to rotate around a center point:
        e.Graphics.TranslateTransform(center.X , center.Y);
        e.Graphics.RotateTransform(angle);
        e.Graphics.TranslateTransform(-center.X, -center.Y);
        // draw one object and reset
        e.Graphics.DrawRectangle(Pens.Green, R0);
        e.Graphics.ResetTransform();
        // for testing (and hittesting): this is the unrotated obejct:
        e.Graphics.DrawRectangle(Pens.LightGray, R0);
        // allowing for any way the rubber band is drawn..
        // ..should be moved to a helper function!  
        Size S = new Size( Math.Abs(downMouse.X - curMouse.X), 
                           Math.Abs(downMouse.Y - curMouse.Y));
        Point P0 = new Point(Math.Min(downMouse.X, curMouse.X), 
                           Math.Min(downMouse.Y, curMouse.Y));
        RM = new Rectangle(P0, S);
        // the ruber band
        e.Graphics.DrawRectangle(Pens.Red, RM);
    }
    private void canvas_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        curMouse = e.Location;
        canvas.Invalidate();
    }
    private void canvas_MouseDown(object sender, MouseEventArgs e)
    {
        downMouse = e.Location;
        curMouse = e.Location;
    }
