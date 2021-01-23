    private void SomeEventOccured(object sender, RoutedEventArgs e)
     {
       var sb = _customUserControl.Expand;
       sb.SetValue(Storyboard.TargetPropertyProperty, new PropertyPath(CustomUserControl.WidthProperty));
       sb.SetValue(Storyboard.TargetNameProperty, _customUserControl.Name);
       sb.Begin();
     }
