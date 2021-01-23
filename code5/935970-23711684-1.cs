    Point mouseOffset = new Point();
    userControl.PreviewMouseLeftButtonDown += (sender, e) =>
    {
        mouseOffset = Mouse.GetPosition(userControl);
        userControl.CaptureMouse();
    };
    userControl.PreviewMouseMove += (sender, e) =>
    {
        if (userControl.IsMouseCaptured)
        {
            Point mouseDelta = Mouse.GetPosition(userControl);
            mouseDelta.Offset(-mouseOffset.X, -mouseOffset.Y);
            userControl.Margin = new Thickness(
                userControl.Margin.Left + mouseDelta.X,
                userControl.Margin.Top + mouseDelta.Y,
                userControl.Margin.Right - mouseDelta.X,
                userControl.Margin.Bottom - mouseDelta.Y);
        }
    };
    userControl.PreviewMouseLeftButtonUp += (sender, e) =>
    {
        userControl.ReleaseMouseCapture();
    };
