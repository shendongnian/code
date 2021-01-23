    // simple but effective floodfill
    void Fill4(Bitmap bmp, Point pt, Color c0, Color c1)
    {
        Rectangle bmpRect = new Rectangle(Point.Empty, bmp.Size);
        Stack<Point> stack = new Stack<Point>();
        int x0 = pt.X;
        int y0 = pt.Y;
        stack.Push(new Point(x0, y0) );
        while (stack.Any() )
        {
            Point p = stack.Pop();
            if (!bmpRect.Contains(p)) continue;
            Color cx = bmp.GetPixel(p.X, p.Y);
            if (cx == Color.Black) return;
            if (cx == SeaColor) return;
            if (cx == c0)
            {
                bmp.SetPixel(p.X, p.Y, c1);
                stack.Push(new Point(p.X, p.Y + 1));
                stack.Push(new Point(p.X, p.Y - 1));
                stack.Push(new Point(p.X + 1, p.Y));
                stack.Push(new Point(p.X - 1, p.Y));
            }
        }
    }
    // create a random color for the test
    Random R = new Random();
    // current and last mouse location
    Point mouseLoc = Point.Empty;
    Point lastMouseLoc = Point.Empty;
    // recognize that we have move inside the same state
    Color lastColor = Color.White;
    // recognize the outside parts of the map
    Color SeaColor = Color.Aquamarine;
    // start a timer since Hover works only once
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        mouseLoc = e.Location;
        timer1.Stop();
        timer1.Interval = 333;
        timer1.Start();
    }
    private void timer1_Tick(object sender, EventArgs e)
    {
        // I keep the map in the Background image
        Bitmap bmp = (Bitmap)pictureBox1.BackgroundImage;
        // still in the same stae: nothing to do
        if (lastColor == bmp.GetPixel(mouseLoc.X, mouseLoc.Y)) return;
        // a random color
        Color nextColor =  Color.FromArgb(255, R.Next(255), R.Next(255), R.Next(256));
        // we've been in the map before, so we restore the last state to white
        if (lastMouseLoc != Point.Empty) 
            Fill4(bmp, lastMouseLoc, bmp.GetPixel(lastMouseLoc.X, lastMouseLoc.Y), Color.White );
        // now we color the current state
        Fill4(bmp, mouseLoc, bmp.GetPixel(mouseLoc.X, mouseLoc.Y), nextColor);
        // remember things, show image and stop the timer
        lastMouseLoc = mouseLoc;
        lastColor = nextColor;
        pictureBox1.Image = bmp;
        timer1.Stop();
    }
