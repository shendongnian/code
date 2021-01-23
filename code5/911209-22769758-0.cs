    Point pt = ...
    VisualTreeHelper.HitTest(myCanvas, null,
                             new HitTestResultCallback(MyHitTestResult),
                             new PointHitTestParameters(pt));
    ...
    private HitTestResultBehavior MyHitTestResult(HitTestResult result)
    {
        DoSomethingWith(result.VisualHit);
        //Set the behavior to return visuals at all z-order levels. 
        return HitTestResultBehavior.Continue;
    }
