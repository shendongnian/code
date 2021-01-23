    var scrollViewer = new ScrollViewer()
    {
        HorizontalScrollBarVisibility = ScrollBarVisibility.Auto,
        VerticalScrollBarVisibility = ScrollBarVisibility.Auto
    };
    
    scrollViewer.AddHandler(UIElement.MouseWheelEvent, new RoutedEventHandler(this.MouseWheelHandler), true);
    var stackPanel = new StackPanel();
    scrollViewer.Content = stackPanel; 
