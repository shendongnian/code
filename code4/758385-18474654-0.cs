            var storyboard = new Storyboard();
            var timeline = new DoubleAnimationUsingKeyFrames
            {
                KeyFrames = new DoubleKeyFrameCollection
                {
                    new EasingDoubleKeyFrame(0),
                    new EasingDoubleKeyFrame(1, KeyTime.FromTimeSpan(new TimeSpan(0, 0, 4)))
                }
            };
            storyboard.BeginAnimation(OpacityProperty, timeline);
