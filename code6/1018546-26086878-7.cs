	public Task<List<Category>> GetAllCategoriesAsync(Uri CoursesLink)
	{
		var tcs = new TaskCompletionSource<List<Category>>();
		List<Category> categories = new List<Category>();
		using (WebBrowser browser = new WebBrowser())
		{
			browser.DocumentCompleted += (s, e) =>
			{
				switch (browser.ReadyState)
				{
					case WebBrowserReadyState.Complete:
						// TODO: your processing, filling categories
						tcs.SetResult(categories);
						break;
						// TODO: error processing
				}
			};
			browser.Navigate(CoursesLink);
		}
		return tcs.Task;
	}
    //...
	var task = GetAllCategoriesAsync(CoursesLink);
	task.Wait();
	var categories = task.Result;
    // OR:
	var categories = GetAllCategoriesAsync(CoursesLink).Result;
