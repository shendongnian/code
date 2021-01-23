    void Main()
    {
        var cts=new CancellationTokenSource();
        RunPeriodicAsync(cts.Token);
    	//sometime later
    	cts.Cancel();
    }
    async Task RunPeriodicAsync(CancellationToken ct)
    {
        while(!ct.IsCancellationRequested)
        {
            await Task.Delay(1000);
    		DoTheWork();
        }
    }
