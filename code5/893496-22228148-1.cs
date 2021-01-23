    void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Storyboard sb = new Storyboard();   
        
            DoubleAnimation daScaleX = new DoubleAnimation();
            daScaleX.From = 1;
            daScaleX.To = 2;
            daScaleX.Duration = TimeSpan.FromMilliseconds(300);
            DoubleAnimation daScaleY = new DoubleAnimation();
            daScaleY.From = 1;
            daScaleY.To = 2;
            daScaleY.Duration = TimeSpan.FromMilliseconds(300);
            BounceEase easing = new BounceEase()
            {
                EasingMode = EasingMode.EaseOut
            };
            daScaleX.EasingFunction = easing;
            daScaleY.EasingFunction = easing;
            Storyboard.SetTargetProperty(daScaleX, new PropertyPath("RenderTransform.ScaleX"));
            Storyboard.SetTarget(daScaleX, rect);
            Storyboard.SetTargetProperty(daScaleY, new PropertyPath("RenderTransform.ScaleY"));
            Storyboard.SetTarget(daScaleY, rect);
          
            sb.Children.Add(daScaleX);
            sb.Children.Add(daScaleY);
            sb.Begin();
        }
