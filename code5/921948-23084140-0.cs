      protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var sb = new Storyboard();
            var animation2 = new DoubleAnimationUsingKeyFrames();
            animation2.BeginTime = TimeSpan.FromMilliseconds(6);
            var ease0 = new EasingDoubleKeyFrame() { KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(0)), Value = 0 };
            var ease1 = new EasingDoubleKeyFrame() { KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(2500)), Value = 40 };
            var ease2 = new EasingDoubleKeyFrame() { KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(4000)), Value = 60 };
            var ease3 = new EasingDoubleKeyFrame() { KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(4100)), Value = 0 };
            animation2.KeyFrames.Add(ease0);
            animation2.KeyFrames.Add(ease1);
            animation2.KeyFrames.Add(ease2);
            animation2.KeyFrames.Add(ease3);
            Storyboard.SetTargetProperty(animation2, "(UIElement.Projection).(PlaneProjection.RotationY)");
            Storyboard.SetTarget(animation2, grid2);
            sb.Children.Add(animation2);
            sb.Completed += (se, argss) =>
            {
            };
            sb.Begin();
        }
