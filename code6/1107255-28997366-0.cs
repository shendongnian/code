    static void Main(string[] args)
    {
        Object windowLock = new object();
        MainWindow window = null;
        Thread thread = new Thread(() =>
        {
            Dispatcher workerDispatcher = null;
            SynchronizationContext.SetSynchronizationContext(new DispatcherSynchronizationContext(Dispatcher.CurrentDispatcher));
            workerDispatcher = Dispatcher.CurrentDispatcher;
            lock (windowLock)
            {
                window = new MainWindow();
            }
            window.Closed += (s, e) => Dispatcher.CurrentDispatcher.BeginInvokeShutdown(DispatcherPriority.Background);
            window.Show();
            Dispatcher.Run();
        });
        thread.SetApartmentState(ApartmentState.STA);
        thread.Start();
        Thread.Sleep(15000);
            
        lock (windowLock)
        {
            if (null != window) // Highly unlikely, but not impossible.
            {
                window.Dispatcher.Invoke(() =>
                {
                    window.Close();
                });
            }
        }
    }
