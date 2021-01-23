    void Window1_Loaded(object sender, RoutedEventArgs e)
    
        {
    
            DoubleAnimation doubleAnimation = new DoubleAnimation();
    
            doubleAnimation.From = -tbmarquee.ActualWidth;
    
            doubleAnimation.To = canMain.ActualWidth;
    
            doubleAnimation.RepeatBehavior = RepeatBehavior.Forever;
    
            doubleAnimation.Duration = new Duration(TimeSpan.Parse("0:0:10"));
    
            tbmarquee.BeginAnimation(Canvas.LeftProperty, doubleAnimation);
    
        }
