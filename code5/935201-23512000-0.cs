    static void Main(string[] args)
    {
        // do async method for each stock in the list
        Task<IEnumerable<string>> symbols = Task.FromResult(Enumerable.Range(1, 5).Select (e => e.ToString()));
    	
        List<Task> tasks = new List<Task>();
    
        try
        {
            for (int i = 0; i < symbols.Result.Count(); i++)
            {
                 string symbol = symbols.Result.ElementAtOrDefault(i);
                 Task t = getCalculationsDataAsync(symbol, "amex", tasks);
                 tasks.Add(t);			 
            }		        
    		
    		Console.WriteLine("Tasks Count:"+ tasks.Count());						
            Task.WaitAll(tasks.ToArray());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    
    public static void getThreadStatus(List<Task> taskList)
    {
        int count = 0;
    
        foreach (Task t in taskList)
        {
    	    Console.WriteLine("Status " + t.Status);
            if (t.Status == TaskStatus.Running)
            {
                count += 1;
    			Console.WriteLine("A task is running");
            }
        }
    
        //Console.WriteLine(count + " threads are running.");
    }
    
    public static async Task getCalculationsDataAsync(string symbol, string market, List<Task> tasks)
    {
        Console.WriteLine("Starting task");
    	var delay = new Random((int)DateTime.Now.Ticks).Next(5000);
    	Console.WriteLine("Delay:" + delay);
        await Task.Delay(delay);
    	Console.WriteLine("Finished task");
    	getThreadStatus(tasks);
    }
