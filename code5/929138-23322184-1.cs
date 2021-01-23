    private void LoadedTabControl_Loaded(object sender, RoutedEventArgs e)
    {
      double contentWidth = ((FrameworkElement)((TabItem)tabCtrl.SelectedItem).Content).ActualWidth;
      double max = 0;
      foreach (TabItem tab in tabCtrl.Items)
      {
        ((FrameworkElement)tab.Content).Measure(new Size(contentWidth, double.PositiveInfinity));
        max = Math.Max(((FrameworkElement)tab.Content).DesiredSize.Height, max);
      }
      foreach (TabItem tab in tabCtrl.Items)
      {
        ((FrameworkElement)tab.Content).Height = max;
      }
    }
