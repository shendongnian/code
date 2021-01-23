	protected override void OnNavigatedTo(NavigationEventArgs e)
	{
		base.OnNavigatedTo(e);
		if (NavigationContext.QueryString.ContainsKey("Page"))
		{
			var page = NavigationContext.QueryString["Page"];
			IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
			//store it in the settings 
			if (!settings.Contains("qsPage"))
			{
				//if setting has not been created, add it
				settings.Add("qsPage", page);
			}
			else
			{
				//store a the page in the setting
				settings["qsPage"] = page;
			}
			browser.Navigate(new Uri("/f" + page + ".html", UriKind.Relative));
		}
	}
