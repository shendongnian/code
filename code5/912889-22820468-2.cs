	const int max = 5;
	var tasks = new System.Threading.Tasks.Task[max];
	for (int i = 0; i < max; i++)
	{
		var copy = i;
		// start execution immediately
		tasks[i] = System.Threading.Tasks.Task.Factory.StartNew(() => callback(copy));
	}
	System.Threading.Tasks.Task.WaitAll(tasks);
