    public static readonly RoutedEvent ShowBlackoutEvent =
        EventManager.RegisterRoutedEvent("ShowBlackout", RoutingStrategy.Bubble, 
                                  typeof(RoutedEventHandler), typeof(MainWindow));
    public static void AddShowBlackoutHandler(DependencyObject d,
                                              RoutedEventHandler handler)
    {
        UIElement uie = d as UIElement;
        if (uie != null)
        {
           uie.AddHandler(MainWindow.ShowBlackoutEvent, handler);
        }
    }
    public static void RemoveShowBlackoutHandler(DependencyObject d,
                                                 RoutedEventHandler handler)
    {
       UIElement uie = d as UIElement;
       if (uie != null)
       {
          uie.RemoveHandler(MainWindow.ShowBlackoutEvent, handler);
       }
    }
