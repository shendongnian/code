    private void myButton_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        DoubleAnimation _DoubleAnimation = new DoubleAnimation();
        _DoubleAnimation.To = 100;
        _DoubleAnimation.Duration = new Duration(TimeSpan.FromSeconds(1));
        myButton.BeginAnimation(Button.WidthProperty, _DoubleAnimation);
    }
