    void ShowCustomToolTip(string text, Control targetControl, int duration = 1000, int x = 0, int y = 0)
    {
        customToolTip.Text = text;
        customToolTip.Visible = true;
        Point absoluteLocation = targetControl.FindForm().PointToClient(
            targetcontrol.Parent.PointToScreen(control.Location));
        // the crucial line that needs to be changed, I guess
        customToolTip.Location = new Point(absoluteLocation.X + x, absoluteLocation.Y + y);
        Set.Timer(duration);
        customToolTip.Hide();
    }
