    private void Button_BackUpSave_Click(object sender, RoutedEventArgs e)
    {
       EnableDisableBackUpSaveButton(false);
    }
    private void EnableDisableBackUpSaveButton(bool value)
    {
       BooleanAnimationUsingKeyFrames animation = 
                                  new BooleanAnimationUsingKeyFrames();
       DiscreteBooleanKeyFrame keyFrame = new DiscreteBooleanKeyFrame(value, 
                               KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(0)));
       animation.KeyFrames.Add(keyFrame);
       BackUpSave.BeginAnimation(Button.IsEnabledProperty, animation);
    }
