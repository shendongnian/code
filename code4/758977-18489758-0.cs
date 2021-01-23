	protected override void OnNavigatedTo(NavigationEventArgs e)
	{
		base.OnNavigatedTo(e);
		if (NavigationContext.QueryString.ContainsKey("Page"))
		{
			var page = NavigationContext.QueryString["Page"];
			
			//store it in a session variable
			session["svPage"] = page ;
			browser.Navigate(new Uri("/f" + page + ".html", UriKind.Relative));
		}
	}
