	private ICommand _onCopyHyperlink;
	public ICommand OnCopyHyperlink
	{
		get
		{
			return _onCopyHyperlink ?? (_onCopyHyperlink = new RelayCommand<Uri>(
				hyperlink =>
				{
					Clipboard.SetText(hyperlink.OriginalString);
				}));
		}
	}
