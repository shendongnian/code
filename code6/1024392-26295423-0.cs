    private void OnUnloaded(object sender, RoutedEventArgs routedEventArgs)
    {
      var dc = DataContext as IViewModel;
      if (dc != null && !dc.IsClosed)
        dc.CloseViewModel(null);
    }
