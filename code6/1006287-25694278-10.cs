    private static void SetCursor(int x, int y)
    {
        // Left boundary
        var xL = (int)App.Current.MainWindow.Left;
        // Right boundary
        var xR = xL + (int)App.Current.MainWindow.Width;
        // Top boundary
        var yT = (int)App.Current.MainWindow.Top;
        // Bottom boundary
        var yB = yT + (int)App.Current.MainWindow.Height;
        x = x + xL;
        y = y + yT;
        if (x < xL)
        {
            x = xL;
        }
        else if (x > xR)
        {
            x = xR;
        }
        if (y < yT)
        {
            y = yT;
        }
        else if (y > yB)
        {
            y = yB;
        }
        SetCursorPos(x, y);
    }
