    const int AJAX_DELAY = 2000; // non-deterministic wait for AJAX dynamic code
    const int AJAX_DELAY_STEP = 500;
    
    // wait until webBrowser.Busy == false or timed out
    async Task<bool> AjaxDelay(CancellationToken ct, int timeout)
    {
        using (var cts = CancellationTokenSource.CreateLinkedTokenSource(ct))
        {
            cts.CancelAfter(timeout);
            while (true)
            {
                try
                {
                    await Task.Delay(AJAX_DELAY_STEP, cts.Token);
                    var busy = (bool)this.webBrowser.ActiveXInstance.GetType().InvokeMember("Busy", System.Reflection.BindingFlags.GetProperty, null, this.webBrowser.ActiveXInstance, new object[] { });
                    if (!busy)
                        return true;
                }
                catch (OperationCanceledException)
                {
                    if (cts.IsCancellationRequested && !ct.IsCancellationRequested)
                        return false;
                    throw;
                }
            }
        }
    }
