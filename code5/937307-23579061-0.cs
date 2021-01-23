	public override bool Enabled
	{
		get
		{
			return System.Windows.Threading.Dispatcher.CurrentDispatcher.Invoke(() => { return ((ISomethingView)View).ViewModel.Enabled; });
		}
	}
