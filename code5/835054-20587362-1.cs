    thread = new Thread(() => method(App.Current.Dispatcher));
    void method(Dispatcher dispatcher)
    {
       ....
       Timers.Add(new DispatcherTimer(DispatcherPriority.Background, dispatcher));
       Timers[Timers.Count - 1] = new DispatcherTimer(DispatcherPriority.Background,
                                                      dispatcher);
       ...
    }
