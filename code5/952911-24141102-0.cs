    if(!DesignerProperties.GetIsInDesignMode(this)) {
        ExpandEvent = EventManager.RegisterRoutedEvent(
            "Expanded",
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(Settings)
        );
    }
