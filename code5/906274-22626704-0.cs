    // The method to test
    public static async Task IdleAsync(CancellationToken token)
    {
        while (true)
        {
            token.ThrowIfCancellationRequested();
            await Dispatcher.Yield(DispatcherPriority.ApplicationIdle);
            Console.WriteLine("Idle!");
        }
    }
    // The unit test method
    [TestMethod]
    public async Task TestIdleAsync()
    {
        var cts = new CancellationTokenSource(1000);
        var task = RunOnWpfThreadAsync(() => IdleAsync(cts.Token));
        try
        {
            await task;
        }
        catch
        {
            if (!task.IsCanceled)
                throw;
        }
    }
    // non-generic RunOnWpfThreadAsync
    public static Task RunOnWpfThreadAsync(Func<Task> funcAsync)
    {
        // convert Task to Task<object>: http://stackoverflow.com/q/22541734/1768303
        return RunOnWpfThreadAsync(async () => {
            await funcAsync().ConfigureAwait(false); return Type.Missing; });
    }
    // generic RunOnWpfThreadAsync<TResult>
    public static async Task<TResult> RunOnWpfThreadAsync<TResult>(Func<Task<TResult>> funcAsync)
    {
        var tcs = new TaskCompletionSource<Task<TResult>>();
        Action startup = async () =>
        {
            // this runs on the WPF thread
            var task = funcAsync();
            try
            {
                await task;
            }
            catch
            {
            }
            // propogate result, exception or cancellation 
            tcs.SetResult(task);
            // request the WPF tread to end
            // the message loop inside Dispatcher.Run() will exit
            System.Windows.Threading.Dispatcher.ExitAllFrames();
        };
        // the WPF thread entry point
        ThreadStart threadStart = () =>
        {
            // post the startup callback
            // it will be invoked when the message loop starts pumping
            System.Windows.Threading.Dispatcher.CurrentDispatcher.BeginInvoke(startup);
            // run the WPF Dispatcher message loop
            System.Windows.Threading.Dispatcher.Run();
        };
        // start and run the STA thread
        var thread = new Thread(threadStart);
        thread.SetApartmentState(ApartmentState.STA);
        thread.IsBackground = true;
        thread.Start();
        try
        {
            // propogate result, exception or cancellation
            return await tcs.Task.Unwrap().ConfigureAwait(false);
        }
        finally
        {
            // make sure the thread has fully come to an end
            thread.Join();
        }
    }
 
