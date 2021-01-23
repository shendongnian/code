    private void chart1_Paint(object sender, PaintEventArgs e)
    {
        double limit = hl.Y;    // get the limit value
        hl.X = 0;               // reset the x value of the annotation
        List<GraphicsPath> paths = getPaths(chart1.ChartAreas[0], chart1.Series[0], limit);
        using (SolidBrush brush = new SolidBrush(Color.FromArgb(127, Color.Red)))
            foreach (GraphicsPath gp in paths)
                { e.Graphics.FillPath(brush, gp); gp.Dispose(); }
    }
