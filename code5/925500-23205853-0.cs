    protected override void OnLaunched(LaunchActivatedEventArgs e)
	{
		Frame rootFrame = Window.Current.Content as Frame;
		if (rootFrame == null)
		{
			rootFrame = new Frame();
			rootFrame.CacheSize = 1;
			Window.Current.Content = rootFrame;
			// The following checks to see if the value of the password is set and if it is not it redirects to the save password page - else it loads the main page.
			Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
			Windows.Storage.StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
			if (localSettings.Values["myPassword"] == null)
			{
				rootFrame.Navigate(typeof(SetPassword));
			}
			else
			{
				rootFrame.Navigate(typeof(MainPage));
			}
		}
		if (rootFrame.Content == null)
		{
			if (rootFrame.ContentTransitions != null)
			{
				this.transitions = new TransitionCollection();
				foreach (var c in rootFrame.ContentTransitions)
				{
					this.transitions.Add(c);
				}
			}
			rootFrame.ContentTransitions = null;
			rootFrame.Navigated += this.RootFrame_FirstNavigated;
			if (!rootFrame.Navigate(typeof(MainPage), e.Arguments))
			{
				throw new Exception("Failed to create initial page");
			}
		}
		Window.Current.Activate();
	}
