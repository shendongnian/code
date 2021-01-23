    var colorAnim = new ColorAnimationUsingKeyFrames()
    {
    	KeyFrames = new ColorKeyFrameCollection
    			{
    				new DiscreteColorKeyFrame(Colors.White, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0.5))),
    				new DiscreteColorKeyFrame(Colors.Blue, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(1))),
    				new DiscreteColorKeyFrame(Colors.White, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(1.5))),
    				new DiscreteColorKeyFrame(Colors.Blue, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(2))),
    			}
    };
    
    var storyBoard = new Storyboard();
    
    storyBoard.Children.Add(colorAnim);
    Storyboard.SetTarget(storyBoard, label);
    Storyboard.SetTargetProperty(storyBoard, new PropertyPath("(Background).(SolidColorBrush.Color)"));
    
    storyBoard.Begin();
