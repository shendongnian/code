    private volatile TaskCompletionSource<int> signal = new TaskCompletionSource<int>();
    
    private void Work()
    {
        while (true)
        {
            Thread.Sleep(5000);
            var oldSignal = signal;
            signal = new TaskCompletionSource<int>()
            //has a waiting thread definitely been signaled by now?
            oldSignal.SetResult(0);
        }
    }
    
    public void WaitForNextEvent()
    {
        signal.Task.Wait();
    }
