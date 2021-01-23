    private void MyCanvas_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
        {
            var pt = e.GetPosition(MyCanvas);
            PointEllipse.SetValue(Canvas.LeftProperty, pt.X);
            PointEllipse.SetValue(Canvas.TopProperty, pt.Y);
        }
    }
