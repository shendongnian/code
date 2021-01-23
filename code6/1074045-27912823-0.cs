    private CountdownEvent _countdownEvent;
    public void Cancel()
    {
        cs.Cancel();
        _countdownEvent.Wait();
        // Update UI
    }
    
    public void StartProcessing()
    {
        try
        {
            _countdownEvent = new CountdownEvent(_Employees.Count);
            Task[] tasks = this._Employees.AsParallel().WithCancellation(cs.Token).Select(x => this.ProcessThisEmployee(x, cs.Token)).ToArray();
            Task.WaitAll(tasks);
        }
        catch (AggregateException ae)
        {
            // error handling code
        }
        // other stuff
    }
    private async Task ProcessThisEmployee(Employee x, CancellationToken token)
    {
        ThirdPartyLibrary library = new ThirdPartyLibrary();
        token.ThrowIfCancellationRequested();
        using(token.Register(() => { library.Clean(); _countdownEvent.Signal(); })
        {
            await Task.Factory.StartNew(() => library.SomeAPI(x) );
        }
    }
