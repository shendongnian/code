    // Retrieve the coordinate of the mouse position.
    Point pt = e.GetPosition((UIElement)sender);
    DataGridRow row = null;
    // Set up a callback to receive the hit test result enumeration.
    VisualTreeHelper.HitTest(myGrid, null,
        new HitTestResultCallback(res => {
           row = res.VisualHit as DataGridRow;
           return row != null ? HitTestResultBehavior.Stop :
             HitTestResultBehavior.Continue;
        }),
        new PointHitTestParameters(pt));
