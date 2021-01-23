    public static bool WaitOneAndPump(WaitHandle handle, int timeoutMillis)
    {
         bool gotHandle = false;
         Stopwatch stopwatch = Stopwatch.StartNew();
         while(!(gotHandle = waitHandle.WaitOne(0)) && stopwatch.ElapsedMilliseconds < timeoutMillis)
         {
             DispatcherFrame frame = new DispatcherFrame();
             Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background,
                 new DispatcherOperationCallback(ExitFrame), frame);
             Dispatcher.PushFrame(frame);
         }
         return gotHandle;
    }
    private static object ExitFrame(object f)
    {
        ((DispatcherFrame)f).Continue = false;
        return null;
    }
