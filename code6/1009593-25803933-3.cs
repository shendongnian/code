	var cts = new CancellationTokenSource();
	
         // Generate some tasks for this example.
	var task1 = Task.Run(async () => await Task.Delay(1000, cts.Token), cts.Token);
	var task2 = Task.Run(async () => await Task.Delay(2000, cts.Token), cts.Token);
	var task3 = Task.Run(async () => await Task.Delay(3000, cts.Token), cts.Token);
	
	List<Task> tasks = new List<Task> {task1, task2, task3};
	while (tasks.Count > 0)
	{
		var finishedTask = await Task.WhenAny(tasks);
		tasks.Remove(finishedTask);
		
		if (finishedTask.Status == TaskStatus.Faulted)
		{
			cts.Cancel();
			// Throw and exit the method.
		}
	}
