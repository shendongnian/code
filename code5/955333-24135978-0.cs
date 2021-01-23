    var tokenSource2 = new CancellationTokenSource();
    CancellationToken ct = tokenSource2.Token;
    var task = Task.Factory.StartNew(() =>
    {
        // Were we already canceled?
        ct.ThrowIfCancellationRequested();
        bool moreToDo = true;
        while (moreToDo)
        {
            // Poll on this property if you have to do 
            // other cleanup before throwing. 
            if (ct.IsCancellationRequested)
            {
                // Clean up here, then...
                ct.ThrowIfCancellationRequested();
            }
        }
    }, tokenSource2.Token); // Pass same token to StartNew.
    tokenSource2.Cancel();
