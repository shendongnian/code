    private void CueStick_MouseDown(object sender, MouseButtonEventArgs e)
    {
        isPictureReadyToDrag = true;
        double x = e.GetPosition(grid1).X;
        double y = e.GetPosition(grid1).Y;
        SetPosition(x, y);
    }
    private void SetPosition(double x, double y)
    {
        CueStick.Margin = new Thickness(x - CueStick.Width / 2,
        y - CueStick.Height / 2, 0, 0);
    }
