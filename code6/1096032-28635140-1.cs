    private void HandleMouseWheel(object sender, MouseWheelEventArgs e)
    {
        var scrollViewer = sender as ScrollViewer;
    
        if (scrollViewer != null && e.Delta > 0 && scrollViewer.VerticalOffset == 0)
        {
            e.Handled = true;
            var eventArg = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta)
                {
                    RoutedEvent = UIElement.MouseWheelEvent,
                    Source = sender
                };
    
            ScrollA.RaiseEvent(eventArg);
        }    
    }
