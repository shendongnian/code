    List<Point> curPoints = new List<Point>();
    List<List<Point>> allPoints = new List<List<Point>>();
    private void pnlPaint_MouseDown(object sender, MouseEventArgs e)
    {
        if (curPoints.Count > 1)
        {
            // begin fresh line or curve
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
        // here you can use DrawLines or DrawCurve
        // current line
        if (curPoints.Count > 1) e.Graphics.DrawCurve(Pens.Red, curPoints.ToArray());
        // other lines or curves
        foreach (List<Point> points in allPoints)
            if (points.Count > 1) e.Graphics.DrawCurve(Pens.Red, points.ToArray());
    }
    private void btn_undo_Click(object sender, EventArgs e)
    {
        if (allPoints.Count > 1)
        {
            allPoints.RemoveAt(allPoints.Count - 1);
            pnlPaint.Invalidate();
        }
    }
    private void btn_save_Click(object sender, EventArgs e)
    {
        string fileName = @"d:\test.bmp";
        Bitmap bmp = new Bitmap(pnlPaint.ClientSize.Width, pnlPaint.ClientSize.Width);
        pnlPaint.DrawToBitmap(bmp, pnlPaint.ClientRectangle);
        bmp.Save(fileName);
    }
