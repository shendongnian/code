    class SplashWindow
    {
        CancellationTokenSource _cts;
        Thread _thread;
    
        // show window
        public void Start(Func<Window> createWindow)
        {
            var tcs = new TaskCompletionSource<bool>(false);
            _cts = new CancellationTokenSource();
            var token = _cts.Token;
    
            _thread = new Thread(() =>
            {
                var window = createWindow();
                window.Loaded += (s, e) =>
                {
                    // window is shown
                    tcs.SetResult(true);
                };
    
                var dispather = Dispatcher.CurrentDispatcher;
                dispather.InvokeAsync(() =>
                    window.Show());
    
                using (token.Register(() =>
                    dispather.BeginInvokeShutdown(DispatcherPriority.Normal),
                    useSynchronizationContext: false))
                {
                    Dispatcher.Run();
                }
    
                window.Close();
            });
    
            _thread.IsBackground = true;
            _thread.SetApartmentState(ApartmentState.STA);
            _thread.Start();
            tcs.Task.Wait();
        }
    
        // hide window
        public void Stop()
        {
            _cts.Cancel();
            _thread.Join();
        }
    }
