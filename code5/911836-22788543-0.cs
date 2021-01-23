    Storyboard storyBoard = new Storyboard
                        { Duration = new Duration(TimeSpan.FromMilliseconds(325)) };
    
    DoubleAnimation anim2 = new DoubleAnimation(1, 500, TimeSpan.FromMilliseconds(325));
    anim2.EasingFunction = new SineEase { EasingMode = EasingMode.EaseInOut };
    anim2.Completed += new EventHandler(myanim_Completed);
    Storyboard.SetTarget(anim2, trans);
    Storyboard.SetTargetProperty(anim2, new PropertyPath(TranslateTransform.XProperty));
    
    DoubleAnimation anim1 = new DoubleAnimation(1, 500, TimeSpan.FromMilliseconds(325));
    anim1.EasingFunction = new SineEase { EasingMode = EasingMode.EaseInOut };
    anim1.Completed += new EventHandler(myanim_Completed);
    Storyboard.SetTarget(anim1, trans);
    Storyboard.SetTargetProperty(anim1, new PropertyPath(TranslateTransform.YProperty));
    storyBoard.Children.Add(anim2);
    storyBoard.Children.Add(anim1);
    
    storyBoard.Begin();
