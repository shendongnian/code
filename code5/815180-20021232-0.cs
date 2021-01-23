    public class PlotClass
    {
        ...
        public void FFTPlot(ZedGraphControl zgc)
        {   
            // Build the point list and attach it to a new curve
            GraphPane myPane = zgc.GraphPane;
            var list = new PointPairList();
            
            // Your code to add the points
            // ...
            
            var myCurve = myPane.AddCurve("My Curve", list, Color.Blue, SymbolType.None);
            zgc.AxisChange();
            zgc.Invalidate();
        }
    }
