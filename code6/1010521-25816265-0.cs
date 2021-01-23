    // We collect the trace data in a list:
    List<Point> points = new List<Point>();
    // each mouse click adds a point
    private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
    {  points.Add(e.Location);   pictureBox1.Invalidate();   }
    // show all all trace points
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {   if (points.Count < 2) return;
        e.Graphics.DrawCurve(Pens.OrangeRed, points.ToArray());
        foreach (Point p in points) 
            e.Graphics.DrawRectangle(Pens.Red, p.X - 1, p.Y - 1, 3, 3);
    }
    // always good to have an undo button
    private void cb_Undo_Click(object sender, EventArgs e)
    { if (points.Count > 0) { points.RemoveAt(points.Count-1); pictureBox1.Invalidate();} }
    // start a new trace by initializing the list
    private void cb_NewTrace_Click(object sender, EventArgs e)
    { points = new List<Point>();  pictureBox1.Invalidate();  }
