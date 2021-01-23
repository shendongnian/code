	static Task DoSomething()
	{
		var ec = ExecutionContext.Capture();
		Task task = null;
		ExecutionContext.Run(ec, _ =>
		{
			CallContext.LogicalSetData("hello", "world");
			var result = Task.Run(() =>
				Debug.WriteLine(new
				{
					Place = "Task.Run",
					Id = Thread.CurrentThread.ManagedThreadId,
					Msg = CallContext.LogicalGetData("hello")
				}))
				.ContinueWith((t) =>
					CallContext.FreeNamedDataSlot("hello")
					);
			task = result;
		}, null);
		return task;
	}
