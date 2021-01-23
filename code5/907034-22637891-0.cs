    void Main()
    {
    	var ct = new CancellationTokenSource(500).Token;
    	 var v = 
    	 Task.Run(() =>
        {
            Thread.Sleep(1000);
    		ct.ThrowIfCancellationRequested();
            return 10;
        }, ct).Result;
    	
        Console.WriteLine(v); //now a TaskCanceledException is thrown.
        Console.Read();
    }
