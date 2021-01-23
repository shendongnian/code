    private void AdornedUIElementPreviewDragOver(object sender, DragEventArgs e)
    {
        PositionAdorner(e.GetPosition(adornedUIElement));
        OnAdornedUIElementPreviewDragOver(sender, e); // Call derived classes here <<<
        if (e.Handled) return; // to bypass base class behaviour
        HitTestResult hitTestResult = VisualTreeHelper.HitTest(adornedUIElement, e.GetPosition(adornedUIElement));
        Control controlUnderMouse = hitTestResult.VisualHit.GetParentOfType<Control>();
        UpdateDragDropEffects(controlUnderMouse, e);
        e.Handled = true;
    }
    /// <summary>
    /// Must be overidden in derived classes to call both the UpdateDropProperties and UpdateDragDropEffects methods to provide feedback for the current drag and drop operation.
    /// </summary>
    /// <param name="sender">The Control that the user dragged the mouse pointer over.</param>
    /// <param name="e">The DragEventArgs object that contains arguments relevant to all drag and drop events.</param>
    protected abstract void OnAdornedUIElementPreviewDragOver(object sender, DragEventArgs e);
