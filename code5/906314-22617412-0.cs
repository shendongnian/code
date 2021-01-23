         private bool IsMouseDown = false;
            Point CPos;
    private void B2_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        UIElement ui = (UIElement)sender;
        IsMouseDown = true;
        ui.CaptureMouse();
        CPos = e.GetPosition(ui);
    }
            void ui2_MouseMove (object sender, MouseEventArgs e)
    {
        Grid b = (Grid)sender;
        if (!IsMouseDown)
            return;
        UIElement parent = (UIElement)b.Parent;
        Canvas.SetLeft(b, Mouse.GetPosition(parent).X - CPos.X);
        Canvas.SetTop(b, Mouse.GetPosition(parent).Y - CPos.Y);
        e.Handled = true;
    }
    private void B2_OnMouseUp(object sender, MouseButtonEventArgs e)
    {
        IsMouseDown = false;
        UIElement ui = (UIElement)sender;
        ui.ReleaseMouseCapture();
        e.Handled = true;
    }
