    private void OnMouseRightButtonUp(object sender, MouseButtonEventArgs e)
    {
        bool isTargetHit = false;
        VisualTreeHelper.HitTest(
            Drawing,
            null,
            r =>
            {
                isTargetHit = true;
                return HitTestResultBehavior.Stop;
            },
            new GeometryHitTestParameters(geom));
        if (isTargetHit)
        {
            MessageBox.Show("You hit the target");
        }
        else
        {
            MessageBox.Show("You did not hit the target");
        }
    }
 
