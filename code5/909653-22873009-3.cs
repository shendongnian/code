    Rect originalBounds = new Rect();
    private void Touch_FrameReported(object sender, TouchFrameEventArgs e)
    {
        TouchPoint myTouchPoint = e.GetPrimaryTouchPoint(ViewPortTestTest);
       // disable scrolling
       if (myTouchPoint.Action == TouchAction.Down) // here probably some other statement like if user hit ellipse
       {
           originalBounds = ViewPortTestTest.Bounds;
           ViewPortTestTest.Bounds = ViewPortTestTest.Viewport; // set current view as Bounds
       }
        // more logic
       // enable once again
       if (myTouchPoint.Action == TouchAction.Up)
            ViewPortTestTest.Bounds = originalBounds;
    }
