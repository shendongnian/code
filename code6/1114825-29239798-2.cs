            Storyboard storyboard = new Storyboard();
            storyboard.Duration = new Duration(TimeSpan.FromSeconds(10));
            DoubleAnimation rotateAnimation = new DoubleAnimation()
            {
                From = 0,
                To = 360,
                Duration = storyboard.Duration,
                RepeatBehavior= new RepeatBehavior(1)
            };
            Storyboard.SetTarget(rotateAnimation, ellipseToRotate);
            Storyboard.SetTargetProperty(rotateAnimation, new PropertyPath("(Ellipse.RenderTransform).(RotateTransform.Angle)"));
            storyboard.Children.Add(rotateAnimation);
            storyboard.Begin();
