    HitTestResult hitTestResult = VisualTreeHelper.HitTest(uiElement, DragStartPosition);
    TreeViewItem listBoxItem = hitTestResult.VisualHit.GetParentOfType<TreeViewItem>();
    if (listBoxItem == null) 
    {
        // user has clicked, but not on a TreeViewItem
    }
