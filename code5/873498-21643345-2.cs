    public static bool WaitOneAndPump2(this WaitHandle waitHandle, int timeoutMillis)
    {
        if (waitHandle.WaitOne(0))
            return true;
          
        DispatcherTimer timer = new DispatcherTimer(DispatcherPriority.Background) 
        { 
            Interval = TimeSpan.FromMilliseconds(50) 
        };
        DispatcherFrame frame = new DispatcherFrame();
        Stopwatch stopwatch = Stopwatch.StartNew();
        bool gotHandle = false;
        timer.Tick += (o, e) =>
        {
           gotHandle = waitHandle.WaitOne(0);
           if (gotHandle || stopwatch.ElapsedMilliseconds > timeoutMillis)
           {
               timer.IsEnabled = false;
               frame.Continue = false;
           }
        };
        timer.IsEnabled = true;
        Dispatcher.PushFrame(frame);
        return gotHandle;
    }
