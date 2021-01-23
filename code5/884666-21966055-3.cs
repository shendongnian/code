    private void myButton_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        ThicknessAnimation animation = new ThicknessAnimation(new Thickness(0), 
                                                              new Thickness(100, 0, 0, 0), 
                                                              new Duration(new TimeSpan(0, 0, 1)),
                                                              FillBehavior.HoldEnd);
        myButton.BeginAnimation(Button.MarginProperty, animation);
     }
