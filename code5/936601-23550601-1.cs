    public static async Task RequestAsyncCool()
    {
        await Task.Factory.StartNew(async () => {
		        await RequestInternalAsync();
		    },
            CancellationToken.None, 
            TaskCreationOptions.DenyChildAttach, 
            TaskScheduler.Current);
    }
