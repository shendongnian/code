    private void CreateAnimation()
    {
        DoubleAnimation doubleAnimation = new DoubleAnimation();
        doubleAnimation.From = -LabelNameSong.ActualWidth;
        doubleAnimation.To = canMain.ActualWidth;
        doubleAnimation.RepeatBehavior = RepeatBehavior.Forever;
        doubleAnimation.Duration = new Duration(TimeSpan.Parse("0:0:10"));
        LabelNameSong.BeginAnimation(Canvas.RightProperty, doubleAnimation);
    }
    void Window1_Loaded(object sender, RoutedEventArgs e)
    {
        CreateAnimation();
    }
    private void LabelNameSong_SizeChanged(object sender, RoutedEventArgs e)
    {
        CreateAnimation();
    }
