    void Main()
    {
    	var b = new BufferBlock<string>();
    	AddToBlockAsync(b);
    	ReadFromBlockAsync(b);
    }
    
    public async Task AddToBlockAsync(BufferBlock<string> b)
    {
    	while (true)
    	{
    		b.Post("hello");
    		await Task.Delay(1000);
    	}
    }
    
    public async Task ReadFromBlockAsync(BufferBlock<string> b)
    {
        await Task.Delay(10000); //let some messages buffer up...
    	while(true)
    	{
    		var msg = await b.ReceiveAsync();
    		Console.WriteLine(msg);
    	}
    }
  
