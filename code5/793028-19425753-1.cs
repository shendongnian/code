    private void DragSourcePreviewMouseMove(object sender, MouseEventArgs e)
    {
        if (isMouseDown && IsConfirmedDrag(e.GetPosition(sender as ListBox)))
        {
            isMouseDown = false;
            ...
            // Start Drag operation
        }
    }
