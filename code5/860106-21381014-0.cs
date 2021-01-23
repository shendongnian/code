	protected override void OnLaunched(LaunchActivatedEventArgs args)
	{
		bool bResumed = false;
		if (args.PreviousExecutionState == ApplicationExecutionState.Suspended)
		{
			AppSimpleState state = LoadState();
			string sType = state.Get(APP_CURRENTVM_KEY);
			if (sType != null)
			{
				INavigationService navigation = IoC.Get<INavigationService>();
				Type t = Type.GetType(sType);
				Debug.Assert(t != null);
				navigation.NavigateToViewModel(t);
				bResumed = true;
			} //eif
		}
		if (!bResumed) DisplayRootView<MainView>();
	}
