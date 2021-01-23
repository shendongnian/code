	class Program
	{
		static async Task DoSomething()
		{
			CallContext.LogicalSetData("hello", "world");
			await Task.Run(() =>
				Debug.WriteLine(new
				{
					Place = "Task.Run",
					Id = Thread.CurrentThread.ManagedThreadId,
					Msg = CallContext.LogicalGetData("hello")
				}))
				.ContinueWith((t) =>
					CallContext.FreeNamedDataSlot("hello")
					);
			Debug.WriteLine(new
			{
				Place = "after await",
				Id = Thread.CurrentThread.ManagedThreadId,
				Msg = CallContext.LogicalGetData("hello")
			});
		}
		static void Main(string[] args)
		{
			DoSomething().Wait();
			Debug.WriteLine(new
			{
				Place = "Main",
				Id = Thread.CurrentThread.ManagedThreadId,
				Msg = CallContext.LogicalGetData("hello")
			});
			Console.ReadLine();
		}
	}
