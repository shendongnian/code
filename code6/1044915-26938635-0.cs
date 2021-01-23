    List<Point> curPoints = new List<Point>();
    List<List<Point>> allPoints = new List<List<Point>>();
    private void pnlPaint_MouseDown(object sender, MouseEventArgs e)
    {
        if (curPoints.Count > 1)
        {
            // begin fresh line
            curPoints.Clear();
            // startpoint
            curPoints.Add(e.Location);
        }
    }
    private void pnlPaint_MouseUp(object sender, MouseEventArgs e)
    {
        if (curPoints.Count > 1)
        {
            // ToList creates a copy
            allPoints.Add(curPoints.ToList());
            curPoints.Clear();
        }
    }
    private void pnlPaint_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button != MouseButtons.Left) return;
        // here we should check if the distance is more than a minimum!
        curPoints.Add(e.Location);
        // let it show
        pnlPaint.Invalidate();
    }
    private void pnlPaint_Paint(object sender, PaintEventArgs e)
    {
        // current lines
        if (curPoints.Count > 1) e.Graphics.DrawCurve(Pens.Red, curPoints.ToArray());
        // other lines
        foreach (List<Point> points in allPoints)
            if (points.Count > 1) e.Graphics.DrawCurve(Pens.Red, points.ToArray());
    }
