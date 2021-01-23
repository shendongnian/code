    // keep your data at class level:
    // lists are more flexible than arrays:
    List<Point> pts = new List<Point>();
     // all drawing in the paint event:
    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        // put the pen creation in a using scope:
        using ( Pen Pen = new Pen(Color.Red, 3f) )
        {  
            // make the corners nicer:
            pen.MiterLimit = pen.Width / 2f;
            // drawing all lines in one call greatly improves quality.
            // we need at least two points:
            if (pts.Count > 1) e.Graphics.DrawLines( Pen, pts);
        }
    }
    // trigger the drawing when needed, eg when you have added more points:
    private void button1_Click(object sender, EventArgs e)
    {
        // maybe add more points..
        pts.AddRange( new Point[]  
                    { new Point(150, 12), new Point(130, 15), new Point(160, 18) } );
        // trigger the paint event
        this.Invalidate();
    }
