      private void AnimatedUserControl2_OnIsVisibleChanged(object sender, EventArgs e)
        {
            var mnb = Template.FindName("MNB", this) as FrameworkElement;
            if (mnb == null)
            {
                return;
            }
            if (Visibility == Visibility.Visible)
            {
                var storyboard = new Storyboard();
                var visibilityAnimation = new ObjectAnimationUsingKeyFrames();
                visibilityAnimation.KeyFrames.Add(new DiscreteObjectKeyFrame(Visibility.Visible,
                                                                             KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0))));
                Storyboard.SetTargetProperty(visibilityAnimation, new PropertyPath(VisibilityProperty));
                storyboard.Children.Add(visibilityAnimation);
                var opacityAnimation = new DoubleAnimation(0, 1, new Duration(TimeSpan.FromSeconds(1)));
                Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath(OpacityProperty));
                storyboard.Children.Add(opacityAnimation);
                var canvasLeftAnimation = new DoubleAnimationUsingKeyFrames();
                canvasLeftAnimation.KeyFrames.Add(new LinearDoubleKeyFrame(200,
                                                                           KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0))));
                canvasLeftAnimation.KeyFrames.Add(new SplineDoubleKeyFrame(0, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(1)),
                                                                           new KeySpline(new Point(0.25, 0.1),
                                                                                         new Point(0.25, 1))));
                Storyboard.SetTargetProperty(canvasLeftAnimation, new PropertyPath(Canvas.LeftProperty));
                storyboard.Children.Add(canvasLeftAnimation);
                mnb.BeginStoryboard(storyboard, HandoffBehavior.SnapshotAndReplace, false);
            }
        }
