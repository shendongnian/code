    private void setPointLabels()
    {
        // All hail the almighty pane.
        GraphPane myPane = theGraph.GraphPane;
    
        // Give us some room to draw labels
        myPane.Margin.Right = 50;
        myPane.Margin.Bottom = 20;
    
        // Dont show the default stuff
        myPane.XAxis.Scale.IsVisible = false;
        myPane.XAxis.MajorTic.IsAllTics = false;
        myPane.XAxis.MinorTic.IsAllTics = false;
        
        // Remove the old labels 
        myPane.GraphObjList.Clear();
    
        // Get the curve showing our data
        LineItem myCurve = (LineItem)myPane.CurveList[0];
    
        // Show a voltage value on the far right
        
        PointPair pt = myCurve.Points[myCurve.Points.Count - 1];
        TextObj text = new TextObj(" " + pt.Y.ToString("f2"), pt.X, pt.Y, CoordType.AxisXYScale, AlignH.Left, AlignV.Center);
        text.ZOrder = ZOrder.A_InFront;
        text.FontSpec.Border.IsVisible = false;
        text.FontSpec.Fill.IsVisible = false;
        myPane.GraphObjList.Add(text);
    
        // Determine a hardcoded yOffset for the labels
        double yOffset = -1.2;
    
        // Determine if we need to fix the center label
        int fixVal = 1;
        if (xScaleSec == 10)
            fixVal = 0;
    
        // Loop over each point in the curve
        for (int i = 0; i < myCurve.Points.Count; i++)
        {
            if (i == 0 ||
                i == (myCurve.Points.Count/4) ||
                i == ((myCurve.Points.Count/2)-fixVal) ||
                i == ((3*myCurve.Points.Count)/4) ||
                i == myCurve.Points.Count-1)
            {
                PointPair aPt = myCurve.Points[i];
    
                // Add a text object just below the x-axis showing the point's x-value
                XDate xVal = new XDate(aPt.X);
                TextObj label = new TextObj(xVal.ToString("hh:mm.ss"), aPt.X, myPane.YAxis.Scale.Min + yOffset, CoordType.AxisXYScale, AlignH.Center, AlignV.Center);
                label.ZOrder = ZOrder.A_InFront;
                label.FontSpec.Fill.IsVisible = false;
                label.FontSpec.Border.IsVisible = false;
                myPane.GraphObjList.Add(label);
    
                // Add a line object on the x-axis representing a tic mark
                LineObj aTic = new LineObj(aPt.X, myPane.YAxis.Scale.Min - (yOffset / 4), aPt.X, myPane.YAxis.Scale.Min + (yOffset / 4));
                myPane.GraphObjList.Add(aTic);
            }
        }
    }
