    #region RoutedEventArgs Properties
    
    private IDisposable disposableClosingEvent;
    public IDisposable DisposableClosingEvent
    {
    	get => this.disposableClosingEvent; set => SetProperty(ref disposableClosingEvent, value, nameof(DisposableClosingEvent));
    }
    
    private IObservable<EventPattern<object, EventArgs>> exitedEventArgs;
    public IObservable<EventPattern<object, EventArgs>> ExitedEventArgs
    {
    	get => exitedEventArgs; set => SetProperty(ref exitedEventArgs, value, nameof(ExitedEventArgs));
    }
    private IDisposable disposableExited;
    public IDisposable DisposableExited
    {
    	get => this.disposableExited; set => SetProperty(ref disposableExited, value, nameof(DisposableExited));
    }
    
    #endregion
