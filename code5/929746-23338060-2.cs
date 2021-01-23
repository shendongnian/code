	private Task<DataValue> _pendingRefresh;
	private void doRefreshData()
	{
		var tcs = new TaskCompletionSource<DataValue>();
        //See if there's one in flight
		var task = Interlocked.CompareExchange(ref _pendingRefresh, tcs.Task, null);
		if (task != null)
		{
			task.Wait(); //Or async, etc
			var items = task.Result;
		}
		else
		{
          try{
			var items = getUpdatedData();
			tcs.SetResult(items); //?
          } catch (Exception ex) {
              tcs.SetException(ex);
              throw;
          } finally {
            //Allow a new call to run 
			Interlocked.Exchange(ref _pendingRefresh, null); 
          }
		}
	}
