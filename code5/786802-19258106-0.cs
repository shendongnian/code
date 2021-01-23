    // Load the X, Y points in two double arrays
    // ...
    var list1 = new FilteredPointList(xArray, yArray);
    // ...
    
    // Use the ZoomEvent to adjust the bounds of the filtered point list
    void zedGraphControl1_ZoomEvent(ZedGraphControl sender, ZoomState oldState, ZoomState newState)
    {
        // The maximum number of point to displayed is based on the width of the graphpane, and the visible range of the X axis
        list1.SetBounds(sender.GraphPane.XAxis.Scale.Min, sender.GraphPane.XAxis.Scale.Max, (int)zgc.GraphPane.Rect.Width);
        // This refreshes the graph when the button is released after a panning operation
        if (newState.Type == ZoomState.StateType.Pan)
            sender.Invalidate();
    }
