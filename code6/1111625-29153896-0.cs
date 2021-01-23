    private const int TimeoutTimeInSeconds = 5;
    private static void Main(string[] args)
    {
    	var tasks = new List<Task>() 
    	{
    		Task.Run( async() => await Task.Delay(30)),
    		Task.Run( async() => await Task.Delay(300)),
    		Task.Run( async() => await Task.Delay(6000)),
    		Task.Run( async() => await Task.Delay(8000))
    	};
    
    	Task.WhenAll(tasks).Wait(TimeSpan.FromSeconds(TimeoutTimeInSeconds));
    
    	var completedTasks = tasks
    		.Where(t => t.Status == TaskStatus.RanToCompletion).ToList();
    	var incompleteTasks = tasks
    		.Where(t => t.Status != TaskStatus.RanToCompletion).ToList();
    
    	Task.WhenAll(incompleteTasks)
    		.ContinueWith(t => { ProcessDelayedTasks(incompleteTasks); });
    
    	ProcessCompletedTasks(completedTasks);
    	Console.ReadKey();
    }
    
    private static void ProcessCompletedTasks(IEnumerable<Task> delayedTasks)
    {
    	Console.WriteLine("Processing completed tasks...");
    }
    
    private static void ProcessDelayedTasks(IEnumerable<Task> delayedTasks)
    {
    	Console.WriteLine("Processing delayed tasks...");
    }
