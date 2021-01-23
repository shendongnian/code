    Task pendingTask = null; // pending session
    CancellationTokenSource cts = null; // CTS for pending session
    // SpellcheckAsync is called by the client app on the UI thread
    public async Task<bool> SpellcheckAsync(CancellationToken token)
    {
        // SpellcheckAsync can be re-entered
        var previousCts = this.cts;
        var newCts = CancellationTokenSource.CreateLinkedTokenSource(token);
        this.cts = newCts;
        if (previousCts != null)
        {
            // cancel the previous session and wait for its termination
            previousCts.Cancel();
            try { await this.pendingTask; } catch { }
        }
        newCts.Token.ThrowIfCancellationRequested();
        this.pendingTask = SpellcheckAsyncHelper(newCts.Token);
        return await this.pendingTask;
    }
    // the actual task logic
    async Task<bool> SpellcheckAsyncHelper(CancellationToken token)
    {
        // do the work (pretty much IO-bound)
        using (...)
        {
            bool doMore = true;
            while (doMore)
            {
                token.ThrowIfCancellationRequested();
                await Task.Delay(500); // placeholder to call the provider
            }
            return doMore;
        }
    }
