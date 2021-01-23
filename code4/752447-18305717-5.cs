	async Task DoNavigationAsync()
	{
		TaskCompletionSource<bool> tcsNavigation = null;
		TaskCompletionSource<bool> tcsDocument = null;
		this.WB.Navigated += (s, e) =>
		{
			if (tcsNavigation.Task.IsCompleted)
				return;
			tcsNavigation.SetResult(true);
		};
		this.WB.DocumentCompleted += (s, e) =>
		{
			if (this.WB.ReadyState != WebBrowserReadyState.Complete)
				return;
			if (tcsDocument.Task.IsCompleted)
				return;
			tcsDocument.SetResult(true); 
		};
		for (var i = 0; i <= 21; i++)
		{
			tcsNavigation = new TaskCompletionSource<bool>();
			tcsDocument = new TaskCompletionSource<bool>();
			this.WB.Navigate("http://www.example.com?i=" + i.ToString());
			await tcsNavigation.Task;
			Debug.Print("Navigated: {0}", this.WB.Document.Url);
			// navigation completed, but the document may still be loading
			await tcsDocument.Task;
			Debug.Print("Loaded: {0}", this.WB.DocumentText);
			// the document has been fully loaded, you can access DOM here
		}
	}
