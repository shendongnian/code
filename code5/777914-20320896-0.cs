    class AsyncWorker
    {
    	Task _pendingTask;
    	CancellationTokenSource _pendingTaskCts;
    
    	// the actual worker task
    	async Task DoWorkAsync(CancellationToken token)
    	{
    		token.ThrowIfCancellationRequested();
    		Debug.WriteLine("Start.");
    		await Task.Delay(100, token);
    		Debug.WriteLine("Done.");
    	}
    
    	// start/restart
    	public void Start(CancellationToken token)
    	{
    		var previousTask = _pendingTask;
    		var previousTaskCts = _pendingTaskCts;
    
    		var thisTaskCts = CancellationTokenSource.CreateLinkedTokenSource(token);
    
    		_pendingTask = null;
    		_pendingTaskCts = thisTaskCts;
    
    		// cancel the previous task
    		if (previousTask != null && !previousTask.IsCompleted)
    			previousTaskCts.Cancel();
    
    		Func<Task> runAsync = async () =>
    		{
    			// await the previous task (cancellation requested)
    			if (previousTask != null)
    				await previousTask.WaitObservingCancellationAsync();
    
    			// if there's a newer task started with Start, this one should be cancelled
    			thisTaskCts.Token.ThrowIfCancellationRequested();
    
    			await DoWorkAsync(thisTaskCts.Token).WaitObservingCancellationAsync();
    		};
    
    		_pendingTask = Task.Factory.StartNew(
    			runAsync,
    			CancellationToken.None,
    			TaskCreationOptions.None,
    			TaskScheduler.FromCurrentSynchronizationContext()).Unwrap();
    	}
    
    	// stop
    	public void Stop()
    	{
    		if (_pendingTask == null)
    			return;
    
    		if (_pendingTask.IsCanceled)
    			return;
    
    		if (_pendingTask.IsFaulted)
    			_pendingTask.Wait(); // instantly throw an exception
    
    		if (!_pendingTask.IsCompleted)
    		{
    			// still running, request cancellation 
    			if (!_pendingTaskCts.IsCancellationRequested)
    				_pendingTaskCts.Cancel();
    
    			// wait for completion
    			if (System.Threading.Thread.CurrentThread.GetApartmentState() == ApartmentState.MTA)
    			{
    				// MTA, blocking wait
    				_pendingTask.WaitObservingCancellation();
    			}
    			else
    			{
    				// TODO: STA, async to sync wait bridge with DoEvents,
    				// similarly to Thread.Join
    			}
    		}
    	}
    }
    
    // useful extensions
    public static class Extras
    {
    	// check if exception is OperationCanceledException
    	public static bool IsOperationCanceledException(this Exception ex)
    	{
    		if (ex is OperationCanceledException)
    			return true;
    
    		var aggEx = ex as AggregateException;
    		return aggEx != null && aggEx.InnerException is OperationCanceledException;
    	}
    
    	// wait asynchrnously for the task to complete and observe exceptions
    	public static async Task WaitObservingCancellationAsync(this Task task)
    	{
    		try
    		{
    			await task;
    		}
    		catch (Exception ex)
    		{
    			// rethrow if anything but OperationCanceledException
    			if (!ex.IsOperationCanceledException())
    				throw;
    		}
    	}
    
    	// wait for the task to complete and observe exceptions
    	public static void WaitObservingCancellation(this Task task)
    	{
    		try
    		{
    			task.Wait();
    		}
    		catch (Exception ex)
    		{
    			// rethrow if anything but OperationCanceledException
    			if (!ex.IsOperationCanceledException())
    				throw;
    		}
    	}
    }
