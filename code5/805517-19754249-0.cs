	public void Start()
	{
		CancellationTokenSource _tokenSource = new CancellationTokenSource();
		var token = _tokenSource.Token;
		Task.Factory.StartNew(() =>
		{
			try
			{
				Parallel.ForEach(_files,
					new ParallelOptions
					{
						MaxDegreeOfParallelism = 5 //limit number of parallel threads 
					},
					file =>
					{
						if (token.IsCancellationRequested)
							return;
						//do work...
						OnDone(file);
					});
			}
			catch (Exception)
			{ }
		}, _tokenSource.Token).ContinueWith(
			t =>
			{
				//finish...
			}
		, TaskScheduler.FromCurrentSynchronizationContext() //to ContinueWith (update UI) from UI thread
		);
	}
	public void OnDone(string fileName)
	{
		// Update the UI, assuming you're using WPF
		someUIComponent.Dispatcher.BeginInvoke(...)
	}
