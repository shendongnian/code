   	async Task<string> MyMethod()
	{
		Contacts cons = new Contacts();
		TaskCompletionSource<int> tcs = new TaskCompletionSource<int>();
			
		cons.SearchCompleted += (sender,args) =>
		{
			tcs.TrySetResult(args.Results);
		};
		cons.SearchAsync(String.Empty, FilterKind.None, "My Contact");
		
		return tcs.Task;
	}
