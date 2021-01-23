    private Point mouseDown = Point.Empty;
    private Stopwatch clickTimer = null;
    private ChartArea chartAreaToZoom = null;
    private void chart1_MouseDown(object sender, MouseEventArgs e)
    {
        HitTestResult result = chart1.HitTest(e.X, e.Y);
        if (result.ChartArea != null)
        {
            chartAreaToZoom = result.ChartArea;
            mouseDown = e.Location;
            clickTimer = Stopwatch.StartNew();
        }
    }
