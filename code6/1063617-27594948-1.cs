    //reference to the graph to draw on
    GraphPane oPane = ZedGraph.MasterPane[0];
    
    double fMinX = 0;
    double fMaxX = 100;
    double fYvalue = 42;
    
    //values for the point pair list to define the horizontal line
    var oPPL = new PointPairList();
    oPPL.Add(fMinX, fYvalue);
    oPPL.Add(fMaxX, fYvalue);
    
    //draw the line as a curve object, then format....
    var oPoints = oPane.AddCurve(string.Empty, oPPL, Color.Red, SymbolType.None);
    oPoints.Line.IsVisible = true;
    oPoints.Line.Style = System.Drawing.Drawing2D.DashStyle.Dash;
    oPoints.Line.Width = 3F;
    oPoints.Symbol.IsVisible = false;
    //and hang on to the curve object so you can move the line around as needed
                oPoints.Clear();
                oPoints.AddPoint(blah blah blah...
