    private void CanvasPreviewMouseMove(object sender, MouseEventArgs e)
    {
        XTransform = e.GetPosition(Rectangle).X;
        YTransform = e.GetPosition(Rectangle).Y;
    }
