    protected override void OnMouseMove(MouseEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
        {
            double deltaDirection = currentPositionX - e.GetPosition(this).X;
            direction = deltaDirection > 0 ? 1 : -1;
            currentPositionX = e.GetPosition(this).X;
        }
        else
        {
            currentPositionX = e.GetPosition(this).X;
        }
    }
