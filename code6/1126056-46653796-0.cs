    async Task MyAsyncTask(
        CancellationToken ct)
    {
        // Keep retrying until the master process is cancelled.
        while (true)
        {
            // Ensure we cancel ourselves if the parent is cancelled.
            ct.ThrowIfCancellationRequested();
    
            var childCts = CancellationTokenSource.CreateLinkedTokenSource(ct);
            // Set a timeout because sometimes stuff gets stuck.
            childCts.CancelAfter(TimeSpan.FromSeconds(32));
            try
            {
                await DoSomethingAsync(childCts.Token);
            }
            // If our attempt timed out, catch so that our retry loop continues.
            // Note: because the token is linked, the parent token may have been
            // cancelled. We check this at the beginning of the while loop.
            catch (OperationCancelledException) when (childCts.IsCancellationRequested)
            {
            }
        }
    }
