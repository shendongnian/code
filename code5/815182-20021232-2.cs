    if (PlotResultCheckbox.Checked)
    {
        PlotClass PlotResult = new PlotClass(); 
        
        GraphPane myPane = zedGraphControl1.GraphPane;
        var list = new PointPairList();
            
        // Your code to add the points using a property exposed by PlotResult
        // ...
        
        var myCurve = myPane.AddCurve("My Curve", list, Color.Blue, SymbolType.None);
        zedGraphControl1.AxisChange();
        zedGraphControl1.Invalidate();
    }
