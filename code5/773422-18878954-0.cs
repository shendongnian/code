    DispatcherTimer Timer;
    private void InitializeTimer()
    {
        Dispatcher.AcceleratorKeyActivated += Dispatcher_AcceleratorKeyActivated;
        Window.Current.CoreWindow.PointerMoved += CoreWindow_PointerMoved;
        Window.Current.CoreWindow.PointerPressed += CoreWindow_PointerPressed;
    
        Timer = new DispatcherTimer();
        Timer.Interval = TimeSpan.FromMinutes(10);
        Timer.Tick += Timer_Tick;
        Timer.Start();
    }
    
    private void CoreWindow_PointerPressed(CoreWindow sender, PointerEventArgs args)
    {
        Timer.Start();
    }
    
    private void CoreWindow_PointerMoved(CoreWindow sender, PointerEventArgs args)
    {
        Timer.Start();
    }
    
    private void Dispatcher_AcceleratorKeyActivated(CoreDispatcher sender, AcceleratorKeyEventArgs args)
    {
        Timer.Start();
    }
    
    private void Timer_Tick(object sender, object e)
    {
        Timer.Stop();
        //TODO: Do logout.
    }
