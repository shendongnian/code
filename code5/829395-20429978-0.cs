        var tokenSource = new CancellationTokenSource();
        CancellationToken ct = tokenSource.Token;
        var task[0] = Task.Factory.StartNew(() =>
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
            tokenSource.Cancel();
        }, tokenSource.Token); // Pass same token to StartNew.
        
