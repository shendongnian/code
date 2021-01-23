    double[] testing = { 0, 1, 2, 3, 4, 5 };
    LineItem myline = zedGraphControl1.GraphPane.AddCurve("testing", testing, testing, Color.Red);
    zedGraphControl1.AxisChange();
    
    ZedGraphControl1.Refresh()
