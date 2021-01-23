    myMediaElement.Play();
    myMediaElement.BeginAnimation(UIElement.OpacityProperty, new DoubleAnimation(myMediaElement.Opacity, 0, TimeSpan.FromSeconds(10)));
    myMediaElement.BeginAnimation(MediaElement.VolumeProperty, new DoubleAnimation(myMediaElement.Volume, 0, TimeSpan.FromSeconds(11)));
    myMediaElement1.Play();
    myMediaElement1.BeginAnimation(UIElement.OpacityProperty, new DoubleAnimation(myMediaElement1.Opacity, 1, TimeSpan.FromSeconds(10)));
    myMediaElement1.BeginAnimation(MediaElement.VolumeProperty, new DoubleAnimation(myMediaElement1.Volume, 1, TimeSpan.FromSeconds(11)));
