    private void DragSourcePreviewMouseMove(object sender, MouseEventArgs e)
    {
        if (isMouseDown && IsDragConfirmed(e.GetPosition(sender as ListBox)))
        {
            // Start your drag operation here
        }
    }
