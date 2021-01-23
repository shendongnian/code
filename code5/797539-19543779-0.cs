    protected override Size MeasureOverride(Size constraint) {
      if (constraint.Width > 800) {
        Application.Current.Dispatcher.BeginInvoke(
          new Action(() => ShowButton = Visibility.Collapsed));
      } else {
        Application.Current.Dispatcher.BeginInvoke(
          new Action(() => ShowButton = Visibility.Visible));
      }
    
      double width = Math.Min(2000.0, constraint.Width);
      double height = Math.Min(50.0, constraint.Height);
    
      return new Size(width, height);
    }
