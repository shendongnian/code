	public override bool ShouldOverrideUrlLoading (WebView view, string url)
	{
		view.LoadUrl (url);
		if (url == "http://stackoverflow.com/about")
		{
			this.linkSelected (url);
		}
		return true;
	}
