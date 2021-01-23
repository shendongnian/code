    public static volatile int _global_Exception_count = 0;
    static async Task Main(string[] args)
    {
    	_global_Exception_count = 0;
    
    	var list = Enumerable.Range(1, 1000000).ToList();
    
    	var tlist = list.Select(async item =>
    	 {
    		 MySingletonAlternative current = null;
    
    		 try
    		 {
    			 current = new MySingletonAlternative();
    		 }
    		 catch (Exception ex) { System.Threading.Interlocked.Increment(ref _global_Exception_count); }
    
    		 return await Task.FromResult(0);
    	 });
    	await Task.WhenAll(tlist);
    
    	Console.WriteLine(_global_Exception_count);
    }// end main
