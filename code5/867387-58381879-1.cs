    public static volatile int _global_Exception_count = 0;
    
        async static Task Main()
        {
        	_global_Exception_count = 0;
        
        	var list = Enumerable.Range(1, 1000000).ToList();
        
        	var taskList = new List<Task>();
        
        	for (int i = 0; i < list.Count(); i++)
        	{
        		var t = Task.Run(() =>
        		{
        
        			MySingletonAlternative current = null;
        
        			try
        			{
        				current = new MySingletonAlternative();
        			}
        			catch (Exception ex)
        			{
        				System.Threading.Interlocked.Increment(ref _global_Exception_count);
        			}
        			if (current != null) { current.Dispose(); }
        		});
        
        		taskList.Add(t);
        	}// end loop	
        
        	await Task.WhenAll(taskList);
        	Console.WriteLine(_global_Exception_count);
        }// end main
