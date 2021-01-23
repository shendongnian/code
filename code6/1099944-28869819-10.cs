	private static void Main()
	{
		CallContext.LogicalSetData(CorrelationManagerSlot, new MyStack());
		ShowCorrelationManagerStack(0.1);
		CallContext.LogicalSetData("slot1", "value1");
		Console.WriteLine(CallContext.LogicalGetData("slot1"));
		Task.FromResult(0).ContinueWith(t =>
		{
			ShowCorrelationManagerStack(0.2);
			CallContext.LogicalSetData("slot1", "value2");
			Console.WriteLine(CallContext.LogicalGetData("slot1"));
		}, 
        CancellationToken.None,
        TaskContinuationOptions.ExecuteSynchronously,
        TaskScheduler.Default);
		ShowCorrelationManagerStack(0.3);
		Console.WriteLine(CallContext.LogicalGetData("slot1"));
        
        // ...
    }
