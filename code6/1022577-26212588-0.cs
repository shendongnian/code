    // Register the routed event
    public static readonly RoutedEvent SelectedEvent = 
    EventManager.RegisterRoutedEvent( "Selected", RoutingStrategy.Bubble, 
    typeof(RoutedEventHandler), typeof(MyCustomControl));
 
    // .NET wrapper
    public event RoutedEventHandler Selected
    {
        add { AddHandler(SelectedEvent, value); } 
        remove { RemoveHandler(SelectedEvent, value); }
    }
