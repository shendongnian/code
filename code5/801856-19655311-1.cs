    public static readonly RoutedEvent ButtonClickedEvent = EventManager.RegisterCrossWindowRoutedEvent(
        "ButtonClicked",
        RoutingStrategy.Bubble,
        typeof(RoutedEventHandler),
        typeof(ChildWindow));
    public static void AddButtonClickedHandler(UIElement target, RoutedEventHandler handler)
    {
        target.AddHandler(ButtonClickedEvent, handler);
    }
    public static void RemoveButtonClickedHandler(UIElement target, RoutedEventHandler handler)
    {
        target.RemoveHandler(ButtonClickedEvent, handler);
    }
