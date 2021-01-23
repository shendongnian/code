    // return true if the job has been done, false if cancelled
    async Task<bool> DoSomethingWithTimeout(int timeout) 
    {
        var tokenSource = new CancellationTokenSource();
        CancellationToken ct = tokenSource.Token;
    
        var doSomethingTask = Task.Factory.StartNew(() =>
        {
            // Were we already canceled?
            if (ct.IsCancellationRequested)
                return;
    
            bool moreToDo = true;
            while (moreToDo)
            {
                // Do useful work here 
                if (ct.IsCancellationRequested)
                    return;
            }
        }, tokenSource.Token); // pass same token to StartNew.
    
        await Task.Delay(timeout); // let the task do its job for this time period
    
        if (!doSomethingTask.IsCompleted)
        {
            // cancel the task 
            tokenSource.Cancel();
            await doSomethingTask; // await untill the cancellation request has been done
            return false;
        }
    
        return true; // job is done
    }
