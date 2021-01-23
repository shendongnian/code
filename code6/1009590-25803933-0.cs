	List<Task> tasks = new List<Task> {task1, task2, task3}; // Show stopping tasks.
	while (tasks.Count > 0)
	{
		var finishedTask = await Task.WhenAny(tasks);
		tasks.Remove(finishedTask);
		
		if (finishedTask.Status == TaskStatus.Faulted)
		{
			// Throw and exit the method.
		}
	}
    // Continuation code goes here.
