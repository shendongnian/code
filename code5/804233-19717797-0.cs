	// create asynchronous task. in order not to block the calling thread,
	// create and start another task in this one and wait for its completion
	var synchronize = new System.Threading.Tasks.Task(() =>
	{					
		var worker = new System.Threading.Tasks.TaskFactory().StartNew(() =>
		{
			// do something work intensive
		});					
		var workCompleted = worker.Wait(10000 /* timeout */);
		if (!workCompleted)
		{
			// worker task has timed-out
		}
	});
