    protected override void OnAdornedUIElementPreviewDragOver(object sender, DragEventArgs e)
    {
        HitTestResult hitTestResult = VisualTreeHelper.HitTest(AdornedUIElement, e.GetPosition(AdornedUIElement));
        ListBox listBoxUnderMouse = hitTestResult.VisualHit.GetParentOfType<ListBox>();
        if (listBoxUnderMouse != null && listBoxUnderMouse.AllowDrop)
        {
            UpdateDropProperties(ListBoxProperties.GetDragDropType(listBoxUnderMouse), ListBoxProperties.GetDropCommand(listBoxUnderMouse));
        }
        UpdateDragDropEffects(listBoxUnderMouse, e);
        e.Handled = true;  // This bypasses base class behaviour
    }
