	public static readonly RoutedEvent ButtonColorChangedEvent = EventManager.RegisterRoutedEvent("ButtonColorChanged",RoutingStrategy.Bubble,typeof(DependencyPropertyChangedEventHandler),typeof(Shirt));
	public event RoutedEventHandler ButtonColorChanged  {
		add {AddHandler(ButtonColorChangedEvent,value);}
		remove { RemoveHandler(ButtonColorChangedEvent, value); }
	}
