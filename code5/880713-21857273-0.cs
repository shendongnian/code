    public static readonly RoutedEvent PlayEvent = EventManager.RegisterEvent( "Play", . . . );
    public event RoutedEventHandler Play {
        add { AddHandler( PlayEvent, value ); }
        remove { RemoveHandler( PlayEvent, value ); }
    }
    public static readonly RoutedEvent StopEvent = EventManager.RegisterEvent( "Stop", . . . );
    public event RoutedEventHandler Stop {
        add { AddHandler( StopEvent, value ); }
        remove { Removehandler( StopEvent, value ); }
    }
    . . . 
