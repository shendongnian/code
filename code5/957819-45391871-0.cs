        public static Task PumpInvokeAsync(this Dispatcher dispatcher, Delegate action, params object[] args)
        {
            var completer = new TaskCompletionSource<bool>();
            // exit if we don't have a valid dispatcher
            if (dispatcher == null || dispatcher.HasShutdownStarted || dispatcher.HasShutdownFinished)
            {
                completer.TrySetResult(true);
                return completer.Task;
            }
            var threadFinished = new ManualResetEvent(false);
            ThreadPool.QueueUserWorkItem(async (o) =>
            {
                await dispatcher?.InvokeAsync(() =>
                {
                    action.DynamicInvoke(o as object[]);
                });
                threadFinished.Set();
                completer.TrySetResult(true);
            }, args);
            // The pumping of queued operations begins here.
            do
            {
                // Error condition checking
                if (dispatcher == null || dispatcher.HasShutdownStarted || dispatcher.HasShutdownFinished)
                    break;
                try
                {
                    // Force the processing of the queue by pumping a new message at lower priority
                    dispatcher.Invoke(() => { }, DispatcherPriority.ContextIdle);
                }
                catch
                {
                    break;
                }
            }
            while (threadFinished.WaitOne(1) == false);
            threadFinished.Dispose();
            threadFinished = null;
            return completer.Task;
        }
