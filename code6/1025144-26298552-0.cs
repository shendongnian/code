	private void startFirst10Tasks()
	{
		List<Task> tasks = new List<Task>();
		//tasks.Add first 10 tasks
		taskHandler(tasks);
	}
	private void taskHandler(List<Task> tasks)
	{
		 Task.Factory.ContinueWhenAny(tasks, winner =>
        	{
        		getNewTasks(tasks.Except(new List<Task>{winner}));
        	});
	}
	private void getNewTasks(List<Task> tasks)
	{
		tasks.Add(
			Task.Factory.StartNew(() => 
			{
				//Next DownloadFileTask
			})
		);
		
		taskHandler(tasks);
	}
