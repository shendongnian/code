    AsyncOp _draw = new AsyncOp();
    
    async void Button_Click(object s, EventArgs args)
    {
    	try
    	{
    		await _draw.RunAsync(async (token) =>
    		{
    			await this.DrawContent(this.TimePeriod, token);
    		}, CancellationToken.None);
    	}
    	catch (Exception ex)
    	{
    		while (ex is AggregateException)
    			ex = ex.InnerException;
    		if (!(ex is OperationCanceledException))
    			MessageBox.Show(ex.Message);
    	}
    }
    
    class AsyncOp
    {
    	Task _pendingTask = null;
    	CancellationTokenSource _pendingCts = null;
    
    	public Task RunAsync(Func<CancellationToken, Task> routine, CancellationToken token)
    	{
    		var oldTask = _pendingTask;
    		var oldCts = _pendingCts;
    
    		var thisCts = CancellationTokenSource.CreateLinkedTokenSource(token);
    
    		Func<Task> startAsync = async () =>
    		{
    			// await the old task
    			if (oldTask != null && !oldTask.IsCompleted)
    			{
    				oldCts.Cancel();
    				try
    				{	
    					await oldTask;
    				}
    				catch (Exception ex)
    				{
    					while (ex is AggregateException)
    						ex = ex.InnerException;
    					if (!(ex is OperationCanceledException))
    						throw;
    				}
    			}
    			// run and await this task
    			await routine(thisCts.Token);
    		};
    
    		_pendingCts = thisCts;
    
    		_pendingTask = Task.Factory.StartNew(
    			startAsync,
    			_pendingCts.Token,
    			TaskCreationOptions.None,
    			TaskScheduler.FromCurrentSynchronizationContext()).Unwrap();
    
    		return _pendingTask; 
    	}
    }
