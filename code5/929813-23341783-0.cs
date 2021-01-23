    HitTestResult result = VisualTreeHelper.HitTest(this, e.GetPosition(this));
    UIElement uIElement = result.VisualHit.GetParentOfType<PropertyPanelUserControl>();
    if (uIElement != null)
    {
        // the user clicked inside the PropertyPanelUserControl control
    }
