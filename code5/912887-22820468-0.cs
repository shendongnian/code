	// global variable
	Random random = new Random(); // used to simulate different work time
	
	// unit of work
	private void callback(int i)
	{
		Console.WriteLine(String.Format("Nr. {0}", i));
		System.Threading.Thread.Sleep(random.Next(100, 1000));
	}	
	const int max = 5;
	var tasks = new System.Threading.Tasks.Task[max];
	for (int i = 0; i < max; i++)
	{
		var copy = i;
		// create the tasks and init the work units
		tasks[i] = new System.Threading.Tasks.Task(() => callback(copy));
	}
	// start the parallel execution
	foreach (var task in tasks)
	{
		task.Start();
	}
	// optionally wait for all tasks to finish
	System.Threading.Tasks.Task.WaitAll(tasks);
