    bool isTargetHit;    
    private void OnMouseRightButtonUp(object sender, MouseButtonEventArgs e)
    {
        isTargetHit = false;
    
        .......
        VisualTreeHelper.HitTest(Drawing, 
                                 null, 
                                 MyCallback, 
                                 new GeometryHitTestParameters(geom));
        
        if(isTargetHit)
        {
            MessageBox.Show("You hit the target");
        }
        else
        {
            MessageBox.Show("You did not hit the target");
        } 
    }
    
    private HitTestResultBehavior MyCallback(HitTestResult result)
    {
        isTargetHit = true;
        return HitTestResultBehavior.Stop;
    }
