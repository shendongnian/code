    private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Storyboard storyboard = new Storyboard();
            ScaleTransform scale = new ScaleTransform(1.0, 1.0);
            animatedRectangle.RenderTransformOrigin = new Point(0.5, 0.5);
            animatedRectangle.RenderTransform = scale;
           
            DoubleAnimation scaleAnimation1 = new DoubleAnimation(1, 2, TimeSpan.FromMilliseconds(1000));
            DoubleAnimation scaleAnimation2 = new DoubleAnimation(1, 2, TimeSpan.FromMilliseconds(1000));
            storyboard.Children.Add(scaleAnimation1);
            storyboard.Children.Add(scaleAnimation2);
            Storyboard.SetTargetProperty(scaleAnimation1, new PropertyPath("RenderTransform.ScaleX"));
            Storyboard.SetTargetProperty(scaleAnimation2, new PropertyPath("RenderTransform.ScaleY"));
            Storyboard.SetTarget(scaleAnimation1, animatedRectangle);
            Storyboard.SetTarget(scaleAnimation2, animatedRectangle);
            storyboard.Begin();         
   
        }        
