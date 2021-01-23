	private ICommand _onClickHyperlink;
	public ICommand OnClickHyperlink
	{
		get
		{
			return _onClickHyperlink ?? (_onClickHyperlink = new RelayCommand<Uri>(
				hyperlink =>
				{
					// Handle Hyperlink click here using Process.Start().
				}));
		}
	}
