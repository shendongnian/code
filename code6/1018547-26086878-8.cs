	public List<Category> GetAllCategories(Uri CoursesLink)
	{
		List<Category> categories = new List<Category>();
		ManualResetEventSlim waitEvent;
		using (WebBrowser browser = new WebBrowser())
		{
			waitEvent = new ManualResetEventSlim();
			browser.DocumentCompleted += (s, e) =>
			{
				switch (browser.ReadyState)
				{
					case WebBrowserReadyState.Complete:
						// TODO: your processing, filling categories
						waitEvent.Set();
						break;
					// TODO: error processing
				}
			};
			browser.Navigate(CoursesLink);
		}
		waitEvent.Wait(); // TODO: timeout?
		return categories;
	}
