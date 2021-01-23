    void Main()
    {
    	var list = new List<int>{ 1,2,3 };
    	var processes = list.Count();
    	foreach (var item in list)
    	{
    		ThreadPool.QueueUserWorkItem(s => {
    			ProcessItem(item);		
    			processes--;
    		});
    	}
    	while (processes > 0) { Thread.Sleep(10); }
    }
    
    static void ProcessItem(int item)
    {
    	Thread.Sleep(100); // do work
    }
