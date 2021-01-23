    private void btnClickMe_Click(object sender, RoutedEventArgs e)
    {
        Popup popUp = new Popup();
        // TODO: Add your elements to the popup here...
        // open the popup at the same coordinates as the button
        var point = CalcPopupOffsets((FrameworkElement)sender);
        popUp.HorizontalOffset = point.X;
        popUp.VerticalOffset = point.Y;
        popUp.IsOpen = true;
    }
    private Point CalcPopupOffsets(FrameworkElement elem)
    {
        // I don't recall the exact specifics on why these
        // calls are needed - but it works.
        var transform = elem.TransformToVisual(this);
        Point point = transform.TransformPoint(new Point(0, 0));
        return point;
    }
