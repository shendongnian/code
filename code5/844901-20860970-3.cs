    void gridTitle_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        //Relese a previous capture:
        Mouse.Capture(null);
        dragging = false;
    }
    void gridTitle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        lastPos = Mouse.GetPosition(null);
        //Capture the mouse to ensure we get all future mouse movements:
        Mouse.Capture(gridTitle);
        dragging = true;
    }
