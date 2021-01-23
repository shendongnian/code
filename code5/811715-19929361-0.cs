    public static readonly RoutedEvent ClickEvent = EventManager.RegisterRoutedEvent(
    "Click", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TabItem));
    
    public event RoutedEventHandler Click
    {
    	add { AddHandler(ClickEvent, value); }
    	remove { RemoveHandler(ClickEvent, value); }
    }
    
    void RaiseClickEvent()
    {
    	RoutedEventArgs newEventArgs = new RoutedEventArgs(TabItem.ClickEvent);
    	RaiseEvent(newEventArgs);
    }
    
    void OnClick()
    {
    	RaiseClickEvent();
    }
