    // Create a thread
    Thread newWindowThread = new Thread(new ThreadStart( () =>
    {
        // Create our context, and install it:
        SynchronizationContext.SetSynchronizationContext(
            new DispatcherSynchronizationContext(
                Dispatcher.CurrentDispatcher));
    
        Window1 tempWindow = new Window1();
        // When the window closes, shut down the dispatcher
        tempWindow.Closed += (s,e) => 
           Dispatcher.CurrentDispatcher.BeginInvokeShutdown(DispatcherPriority.Background);
    
        tempWindow.Show();
        // Start the Dispatcher Processing
        System.Windows.Threading.Dispatcher.Run();
    }));
    // Setup and start thread as before
