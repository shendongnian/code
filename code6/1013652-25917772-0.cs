    int speed = 10;
    int delta = 0;
    private void panOuter_MouseMove(object sender, MouseEventArgs e)
    {
        delta = e.X < panOuter.Width / 2 ? speed : -speed;
        scrollTimer.Start();
    }
    private void panOuter_MouseLeave(object sender, EventArgs e)
    {
        scrollTimer.Stop();
    }
    private void scrollTimer_Tick(object sender, EventArgs e)
    {
        int newLeft = FLP.Left + delta;
        int alpha = panInner.ClientRectangle.Width - FLP.ClientRectangle.Width;
        if (newLeft > 0) { newLeft = 0; scrollTimer.Stop(); }
        else if (  newLeft <  alpha)
        { newLeft = alpha; scrollTimer.Stop(); }
        FLP.Left = newLeft;
    }
