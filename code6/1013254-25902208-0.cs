		public Task Run()
		{
			var items = GetItems();
			var tasks = items.Select(RunItemAsync);
			return Task.WhenAll(tasks);
		}
		private Task RunItemAsync(Item i)
		{
			var subItems = i.GetSubItems();
			var tasks = subItems.Select(s => Task.Factory.StartNew(()=>s.RunSubItem(s)));
			return Task.WhenAll(tasks).ContinueWith(_ => ProcessAsync(i), TaskContinuationOptions.ExecuteSynchronously);
		}
