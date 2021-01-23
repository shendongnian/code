    async Task DoUIThreadWorkAsync(CancellationToken token)
    {
        Func<Task> idleYield = async () =>
            await Dispatcher.Yield(DispatcherPriority.ApplicationIdle);
        var cancellationTcs = new TaskCompletionSource<bool>();
        using (token.Register(() =>
            cancellationTcs.SetCanceled(), useSynchronizationContext: true))
        {
            var i = 0;
            while (true)
            {
                var continueTask = Task.WhenAll(idleYield(), Task.Delay(100));
                await Task.WhenAny(cancellationTcs.Task, continueTask);
                token.ThrowIfCancellationRequested();
                // do the UI-related work
                this.TextBlock.Text = "iteration " + i++;
            }
        }
    }
